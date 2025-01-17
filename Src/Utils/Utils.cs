﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

[assembly: InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("FFS.StaticEcs.Unity")]
[assembly: InternalsVisibleTo("FFS.StaticEcs.Unity.Editor")]

namespace FFS.Libraries.StaticEcs {
    #if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
    #endif
    public static class Utils {
        internal static ushort CalculateMaskLen(ushort count) {
            var len = (ushort) (count >> 6);
            if (count - (len << 6) != 0) {
                len++;
            }

            return len;
        }


        [MethodImpl(AggressiveInlining)]
        public static int CalculateSize(int value) {
            var u = (uint) value;
            if (u == 0) {
                return 0;
            }

            u--;
            u |= u >> 1;
            u |= u >> 2;
            u |= u >> 4;
            u |= u >> 8;
            u |= u >> 16;
            u++;

            return (int) u;
        }

        internal static string GetGenericName(this Type type) {
            if (!type.IsGenericType) {
                return type.Name;
            }

            var genericArguments = type.GetGenericArguments();
            var typeName = type.FullName.Substring(0, type.FullName.IndexOf('`')); // Убираем суффикс `1, `2 и т.д.
            var genericArgs = string.Join(", ", Array.ConvertAll(genericArguments, GetGenericName));

            return $"{typeName}<{genericArgs}>";
        }
    }

    public interface Stateless { }
    
    #if DEBUG || FFS_ECS_ENABLE_DEBUG
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public abstract partial class Ecs<WorldID> where WorldID : struct, IWorldId {
        internal static FileLogger<WorldID> FileLogger;
        
        public static void CreateFileLogger(string logsFilePath, OperationType[] excludedOperations = null, ICsvColumnHandler<WorldID>[] columnWriters = null) {
            if (World.Status != WorldStatus.Created) throw new Exception($"Ecs<{typeof(WorldID)}>, Method: CreateFileLogger, world status not `Created`");
            if (FileLogger != null) throw new Exception("File logger already added");

            FileLogger = new FileLogger<WorldID>(logsFilePath, excludedOperations, columnWriters);
            FileLogger.Enable();
        }
        
        public static void EnableFileLogger() {
            if (FileLogger == null) {
                throw new Exception("File logger not added");
            }
            
            FileLogger.Enable();
        }
        
        public static void DisableFileLogger() {
            if (FileLogger == null) {
                throw new Exception("File logger not added");
            }
            
            FileLogger.Disable();
        }
    }

    public enum OperationType : byte {
        EntityCreate,
        EntityDestroy,
        ComponentRef,
        ComponentRefMut,
        ComponentAdd,
        ComponentPut,
        ComponentDelete,
        TagAdd,
        TagDelete,
        MaskSet,
        MaskDelete,
        EventAdd,
        EventDelete,
        SystemCallInit,
        SystemCallUpdate,
        SystemCallDestroy,
    }


    internal static class TypeData<T> {
        public static readonly string Name;

        static TypeData() {
            Name = typeof(T).Name;
        }
    }
    
    public interface ICsvWriter {
        public void WriteColumn(StreamWriter writer);
    }

    public interface ICsvColumnHandler<WorldId> where WorldId : struct, IWorldId {
        public string ColumnName();

        public void TryAddColumn(Ecs<WorldId>.Entity entity, StreamWriter writer);
    }

    public struct CsvColumnComponentHandler<WorldId, T> : ICsvColumnHandler<WorldId>
        where WorldId : struct, IWorldId
        where T : struct, IComponent, ICsvWriter {
        public string ColumnName() {
            return typeof(T).Name;
        }

        public void TryAddColumn(Ecs<WorldId>.Entity entity, StreamWriter writer) {
            if (Ecs<WorldId>.Components<T>.Value.Has(entity)) {
                Ecs<WorldId>.Components<T>.Value.RefMutInternal(entity).WriteColumn(writer);
            }

            writer.Write(";");
        }
    }

    internal static class FileLogger {
        internal static readonly string[] MethodNames = {
            "CREATE",
            "DESTROY",
            "REF",
            "REF_MUT",
            "ADD",
            "PUT",
            "DEL",
            "ADD",
            "DEL",
            "SET",
            "DEL",
            "EVENT_ADD",
            "EVENT_DEL",
            "SYS_INIT",
            "SYS_UPDATE",
            "SYS_DESTROY",
        };
        
        internal static string MethodName(OperationType operationType) {
            return MethodNames[(int) operationType];
        }
    }

    public sealed class FileLogger<WorldId> : Ecs<WorldId>.IWorldDebugEventListener,
                                              Ecs<WorldId>.IComponentsDebugEventListener
                                              #if !FFS_ECS_DISABLE_TAGS
                                              , Ecs<WorldId>.ITagDebugEventListener,
                                              #endif
                                              #if !FFS_ECS_DISABLE_MASKS
                                              Ecs<WorldId>.IMaskDebugEventListener,
                                              #endif
                                              #if !FFS_ECS_DISABLE_EVENTS
                                              Ecs<WorldId>.IEventsDebugEventListener
                                              #endif
        where WorldId : struct, IWorldId {
        internal static readonly Ecs<WorldId>.Entity EmptyEntity = Ecs<WorldId>.Entity.FromIdx(-1);



        internal readonly string LogsFilePath;
        internal readonly DateTime DateTime;
        internal readonly bool[] ExcludedOperations;
        internal readonly ICsvColumnHandler<WorldId>[] ColumnWriters;

        internal StreamWriter Writer;
        internal int Lines;
        internal int Part;
        internal bool Enabled;

        internal FileLogger(string logsFilePath, OperationType[] excludedOperations = null, ICsvColumnHandler<WorldId>[] columnWriters = null) {
            LogsFilePath = logsFilePath;
            DateTime = DateTime.Now;
            ExcludedOperations = new bool[Enum.GetValues(typeof(OperationType)).Length];
            if (excludedOperations != null) {
                foreach (var operation in excludedOperations) {
                    ExcludedOperations[(int) operation] = true;
                }
            }

            ColumnWriters = columnWriters ?? Array.Empty<ICsvColumnHandler<WorldId>>();
            var files = Directory.GetFiles(logsFilePath);
            foreach (var file in files) {
                if (file.Contains($"entities_log_{typeof(WorldId).Name}")) {
                    File.Delete(file);
                }
            }

            CreateWriter();
        }

        public void Enable() {
            if (!Enabled) {
                Ecs<WorldId>.World.AddWorldDebugEventListener(this);
                Ecs<WorldId>.World.AddComponentsDebugEventListener(this);
                #if !FFS_ECS_DISABLE_TAGS
                Ecs<WorldId>.World.AddTagDebugEventListener(this);
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                Ecs<WorldId>.World.AddMaskDebugEventListener(this);
                #endif
                #if !FFS_ECS_DISABLE_EVENTS
                Ecs<WorldId>.Events.AddEventsDebugEventListener(this);
                #endif
                Enabled = true;
            }
        }

        public void Disable() {
            if (Enabled) {
                Ecs<WorldId>.World.RemoveWorldDebugEventListener(this);
                Ecs<WorldId>.World.RemoveComponentsDebugEventListener(this);
                #if !FFS_ECS_DISABLE_TAGS
                Ecs<WorldId>.World.RemoveTagDebugEventListener(this);
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                Ecs<WorldId>.World.RemoveMaskDebugEventListener(this);
                #endif
                #if !FFS_ECS_DISABLE_EVENTS
                Ecs<WorldId>.Events.RemoveEventsDebugEventListener(this);
                #endif
                Writer.Flush();
                Enabled = false;
            }
        }

        private void CreateWriter() {
            Writer = new StreamWriter($"{LogsFilePath}/entities_log_{typeof(WorldId).Name}_{Part}_{DateTime:yyyy_MM_dd_HH_mm_ss}.csv", true, Encoding.UTF8);

            Writer.Write("EntityId");
            Writer.Write(";");
            Writer.Write("Version");
            Writer.Write(";");
            foreach (var columnWriter in ColumnWriters) {
                Writer.Write(columnWriter.ColumnName());
                Writer.Write(";");
            }

            Writer.Write("Operation");
            Writer.Write(";");
            Writer.WriteLine("Type");
        }
        
        public void Flush() {
            Writer.Flush();
        }

        public void OnWorldInitialized() {
            Enable();
        }

        public void OnWorldDestroyed() {
            Disable();
            Writer.Dispose();
        }

        public void OnWorldResized(int capacity) { }
        
        public void Write(OperationType operation, string type) {
            Write(EmptyEntity, operation, type);
        }

        public void Write(Ecs<WorldId>.Entity entity, OperationType operation, string type) {
            if (ExcludedOperations[(int) operation]) {
                return;
            }
            
            if (entity._id >= 0) {
                Writer.Write(entity._id);
            }

            Writer.Write(";");
            
            if (entity._id >= 0) {
                Writer.Write(entity.Version());
            }

            Writer.Write(";");

            foreach (var columnWriter in ColumnWriters) {
                columnWriter.TryAddColumn(entity, Writer);
            }

            Writer.Write(FileLogger.MethodName(operation));
            Writer.Write(";");
            if (type != null) {
                Writer.WriteLine(type);
            } else {
                Writer.WriteLine();
            }

            Lines++;
            if (Lines >= 1_000_000) {
                Lines = 0;
                Part++;
                Writer.Dispose();
                CreateWriter();
            }
        }

        public void OnEntityCreated(Ecs<WorldId>.Entity entity) {
            Write(entity, OperationType.EntityCreate, null);
        }

        public void OnEntityDestroyed(Ecs<WorldId>.Entity entity) {
            Write(entity, OperationType.EntityDestroy, null);
        }

        public void OnComponentRef<T>(Ecs<WorldId>.Entity entity, ref T component) where T : struct, IComponent {
            Write(entity, OperationType.ComponentRef, TypeData<T>.Name);
        }

        public void OnComponentRefMut<T>(Ecs<WorldId>.Entity entity, ref T component) where T : struct, IComponent {
            Write(entity, OperationType.ComponentRefMut, TypeData<T>.Name);
        }

        public void OnComponentAdd<T>(Ecs<WorldId>.Entity entity, ref T component) where T : struct, IComponent {
            Write(entity, OperationType.ComponentAdd, TypeData<T>.Name);
        }

        public void OnComponentPut<T>(Ecs<WorldId>.Entity entity, ref T component) where T : struct, IComponent {
            Write(entity, OperationType.ComponentPut, TypeData<T>.Name);
        }

        public void OnComponentDelete<T>(Ecs<WorldId>.Entity entity, ref T component) where T : struct, IComponent {
            Write(entity, OperationType.ComponentDelete, TypeData<T>.Name);
        }
        #if !FFS_ECS_DISABLE_TAGS
        public void OnTagAdd<T>(Ecs<WorldId>.Entity entity) where T : struct, ITag {
            Write(entity, OperationType.TagAdd, TypeData<T>.Name);
        }

        public void OnTagDelete<T>(Ecs<WorldId>.Entity entity) where T : struct, ITag {
            Write(entity, OperationType.TagDelete, TypeData<T>.Name);
        }
        #endif
        
        #if !FFS_ECS_DISABLE_MASKS
        public void OnMaskSet<T>(Ecs<WorldId>.Entity entity) where T : struct, IMask {
            Write(entity, OperationType.MaskSet, TypeData<T>.Name);
        }

        public void OnMaskDelete<T>(Ecs<WorldId>.Entity entity) where T : struct, IMask {
            Write(entity, OperationType.MaskDelete, TypeData<T>.Name);
        }
        #endif

        #if !FFS_ECS_DISABLE_EVENTS
        public void OnEventSent<T>(Ecs<WorldId>.Event<T> value) where T : struct, IEvent {
            Write(EmptyEntity, OperationType.EventAdd, TypeData<T>.Name);
        }

        public void OnEventReadAll<T>(Ecs<WorldId>.Event<T> value) where T : struct, IEvent {
            Write(EmptyEntity, OperationType.EventDelete, TypeData<T>.Name);
        }

        public void OnEventSuppress<T>(Ecs<WorldId>.Event<T> value) where T : struct, IEvent {
            Write(EmptyEntity, OperationType.EventDelete, TypeData<T>.Name);
        }
        #endif
    }
    #endif
}

#if ENABLE_IL2CPP
namespace Unity.IL2CPP.CompilerServices {
    using System;

    internal enum Option {
        NullChecks = 1,
        ArrayBoundsChecks = 2,
        DivideByZeroChecks = 3
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    internal class Il2CppSetOptionAttribute : Attribute {
        public Option Option { get; }
        public object Value { get; }

        public Il2CppSetOptionAttribute(Option option, object value) {
            Option = option;
            Value = value;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    internal class Il2CppEagerStaticClassConstructionAttribute : Attribute { }
}
#endif