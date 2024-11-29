![Version](https://img.shields.io/badge/version-0.9.0-blue.svg?style=for-the-badge)

### ЯЗЫК
[RU](./README_RU.md)
[EN](./README.md)
 
# Static ECS - C# Entity component system framework
- Легковесность
- Производительность
- Отсутсвие аллокаций
- Отсутствие зависимостей
- Без Unsafe
- Основан на статике и структурах
- Типобезопасность
- Бесплатные абстракции
- Мощный механизм запросов
- Минимум болерплейта
- Совместимость с Unity и другими C# движками
### Ограничения и особенности:
> - Не потокобезопасен
> - Могут быть незначительные изменения API

## Оглавление
* [Контакты](#контакты)
* [Установка](#установка)
* [Быстрый старт](#быстрый-старт)
* [Концепция](#концепция)
* [Основные типы](#основные-типы)
    * [Entity](#entity)
    * [PackedEntity](#packedentity)
    * [Component](#component)
    * [Tag](#tag)
    * [Mask](#mask)
    * [WorldId](#worldId)
    * [Ecs](#ecs)
    * [World](#world)
    * [Systems](#systems)
    * [Context](#context)
    * [Query](#query)
* [Дополнительные возможности](#дополнительные-возможности)
    * [Идентификаторы компонентов](#идентификаторы-компонентов)
    * [Авто обработчики](#авто-обработчики)
    * [События](#события)
    * [Отношения](отношения)
* [Специальные типы](#специальные-типы)
    * [Components](#components)
    * [ComponentsPool](#componentsPool)
    * [Tags](#tags)
    * [TagsPool](#tagsPool)
    * [Masks](#masks)
    * [MasksPool](#masksPool)
* [Производительность](#производительность)
* [Интеграция в движки](#интеграция-в-движки)
    * [Unity](#unity)
* [Вопрос-ответ](#вопрос-ответ)
* [Лицензия](#лицензия)


# Контакты
* [Telegram](https://t.me/felid_force_studios)
# Установка
* ### В виде исходников
  Со страцины релизов или как архив из нужной ветки. В ветки `master` стабильная проверенная версия
* ### Установка для Unity
  Как git модуль `https://github.com/Felid-Force-Studios/StaticEcs.git` в Unity PackageManager или добавления в `Packages/manifest.json`:


# Быстрый старт
```csharp
using FFS.Libraries.StaticEcs;
// Определяем компоненты
public struct Position : IComponent { public Vector3 Val; }
public struct Velocity : IComponent { public float Val; }

// Определяем идентификатор мира
public struct MyWorldID : IWorldId { }

// Определяем типы-алиасы для удобного доступа к типам библиотеки
public abstract class MyEsc : Ecs<MyWorldID> { }
public abstract class MyWorld : Ecs<MyWorldID>.World { }

// Определяем идентификатор систем
public struct MySystemsID : ISystemsId { }

// Определяем тип-алиас для удобного доступа к системам
public abstract class MySystems : Systems<MySystemsID> { }

// Определояем системы
public readonly struct VelocitySystem : IUpdateSystem {
    public void Update() {
        foreach (var entity in World.QueryEntities.For<All<Types<Position, Velocity>>>()) {
            entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
        }
    }
}

public class Program {
    public static void Main() {
        // Создаем данные мира
        MyEsc.CreateWorld(EcsConfig.Default());
        // Инициализацируем мир
        MyEsc.InitializeWorld();
        
        // Создаем системы
        MySystems.Create();
        MySystems.AddUpdateSystem<VelocitySystem>();

        // Инициализацируем системы
        MySystems.Initialize();

        // Создание сущности
        var entity = MyEsc.Entity.New(
            new Velocity { Val = 1f },
            new Position { Val = Vector3.One }
        );
        // Обновление всех систем - вызывается в каждом кадре
        MySystems.Update();
        // Уничтожение систем
        MySystems.Destroy();
        // Уничтожение мира и очистка всех данных
        MyEsc.DestroyWorld();
    }
}
```

# Концепция
> - Основная идея данной реализации в статике, все данные о мире и компонентах находятся в статических классах, что дает вохможность избегать дорогостоящих виртуальных вызовов, иметь удобный API со множеством сахара
> - Даннный фреймворк нацелен на максмальную простоту использования, скорость и комфорт написания кода без жертв в производительности
> - Доступно создание мульти-миров, строгая типизация, обширные бесплатные абстракции
> - Доступно сокращение мономорфизации дженерик типов и методов для уменьшения исходников кода за счет механизма идентификаторов компонентов (раздел дополнительные возможности)
> - Основан на sparse-set архитектуре, ядро вдохновленно серией библиотек от Leopotam
> - Фреймворк создан для нужд частного проекта и выложен в open-source.


# Основные типы:

### Entity
Сущность - служит для идентификации объекта в игровом мире и доступа к прикрепленным компонентам  
 - Представлена в виде структуры размером 4 байт

<details><summary>Использование</summary>

- Создание:
```csharp
// Создание возможно только с указанием начальных компонентов
// Создание одной сущности
// Способ 1 - с указанием типа компонента (методы перегрузки от 1-5 компонентов)
var entity = MyEsc.Entity.New<Position>();
var entity = MyEsc.Entity.New<Position, Velocity, Name>();

// Способ 2 - с указанием значения компонента (методы перегрузки от 1-5 компонентов)
var entity = MyEsc.Entity.New(new Position(x: 1, y: 1, z: 2));
var entity = MyEsc.Entity.New(
            new Name { Val = "SomeName" },
            new Velocity { Val = 1f },
            new Position { Val = Vector3.One }
);

// Создание множества сущностей
// Способ 1 - с указанием типа компонента (методы перегрузки от 1-5 компонентов)
int count = 100;
MyEsc.Entity.NewOnes<Position>(count);

// Способ 2 - с указанием типа компонента (методы перегрузки от 1-5 компонентов) + делегата инициализации каждой сущности
int count = 100;
Ecs.Entity.NewOnes<Position>(count, static entity => {
    // some init logic for each entity
});

// Способ 3 - с указанием значения компонента (методы перегрузки от 1-5 компонентов)
int count = 100;
MyEsc.Entity.NewOnes(count, new Position(x: 1, y: 1, z: 2));

// Способ 4 - с указанием значения компонента (методы перегрузки от 1-5 компонентов) + делегата инициализации каждой сущности
int count = 100;
MyEsc.Entity.NewOnes(count, new Position(x: 1, y: 1, z: 2), static entity => {
    // some init logic for each entity
});
```

- Основные операции:
```csharp
var entity = MyEsc.Entity.New(
            new Name { Val = "SomeName" },
            new Velocity { Val = 1f },
            new Position { Val = Vector3.One }
);

bool actual = entity.IsActual();         // Проверить не удалена ли сущность в мире
short version = entity.Version();        // Получить версию сущности
var clone = entity.Clone();              // Клонировать сущность и все компоненты, теги, маски
entity.Destroy();                        // Удалить сущность и все компоненты, теги, маски

var entity2 = MyEsc.Entity.New<Name>();
clone.CopyTo(entity2);                   // Копировать все компоненты, теги, маски в указанную сущность

var entity3 = MyEsc.Entity.New<Name>();
entity2.MoveTo(entity3);                 // Перенести все компоненты в указанную сущность и удалить текущую

PackedEntity packed = newEntity.Pack();  // Упаковать сущность с мета информацией о версии для передачи

var str = entity3.ToPrettyString();      // Получить строку со всей информацией о сущности
```
</details>

### PackedEntity
Упакованая сущность - хранит мета информацию сущности, служит для безопасной передачи сущности (например в событиях, компонентах и тд)  
> сущность это просто id, упакованая сущность это id + version  
> просто по id невозможно определить та самая эта сущность что сейчас в мире под этим идентификатором или нет, можно только вместе с версией, для этого упакованая версия
 - Представлена в виде структуры размером 8 байт

<details><summary>Использование</summary>

- Создание:
```csharp
// Создание возможно только через незапакованную сущность
PackedEntity packedEntity = entity.Pack();
```
- Основные операции:
```csharp
PackedEntity packedEntity = entity.Pack();
// Попытаться распаковать сущность в мире идентификатор которого указан через параметр типа, возвращает true если сущность успешно распакована, в out распакованя сущность
if (packedEntity.TryUnpack<WorldID>(out var entity)) {
    // ...
}

PackedEntity packedEntity2 = entity.Pack();
bool equals = packedEntity.Equals(packedEntity2);     // Проверить идентичность упавкованных сущностей
```
</details>

### Component
Компонент - наделяет сущность свойствами  
 - Cущность не может существовать без компонентов, так как сущность без данных это просто идентификатор
 - При удалении последнего компонента сущность удаляется
 - Дает возможность строить запросы поиска только по компонентам
 - Представлен в виде пользовательской структуры с маркер интерфейсом `IComponent`  
 - Представлен в виде struct исключительно по соображениям производительности
Пример:
```c#
public struct Position : IComponent {
    public Vector3 Value;
}
```

<details><summary>Использование</summary>

- Создание:
```c#
// Способ 1 - при создании сущности (аналогично методу Add())
var entity = MyEsc.Entity.New<Position>();

// Или через значение  (аналогично методу Put())
// Нужно быть осторожным с AutoInit и AutoReset (смотри дополнительные возможности)
var entity = MyEsc.Entity.New(new Position(x: 1, y: 1, z: 2));

// Добавление компонента на сущность и возврат ref значения на компонент (в DEBUG режиме будет ошибка если он уже существует на сущности)
ref var position = ref entity.Add<Position>();
// Добавление компонента на сущность (в DEBUG режиме будет ошибка если он уже существует на сущности) (методы перегрузки от 2-5 компонентов)
entity.Add<Position, Velocity>();

// Добавление компонента на сущность если его еще нет, иначе возврат существующего
ref var position = ref entity.TryAdd<Position>();
ref var position = ref entity.TryAdd<Position>(out bool added); // перегрузка где added = true если компонент новый, false если вернулся существующий
// Добавление компонента на сущность если его еще нет (методы перегрузки от 2-5 компонентов)
entity.TryAdd<Position, Velocity>();
entity.TryAdd<Position, Velocity>(out bool added); // перегрузка где added = true если хотя бы 1 компонент новый, false все компоненты существовали ранее

// Помещение компонента через значение. (методы перегрузки от 1-5 компонентов)
// Если компонент уже существует то все данные будут заменены, если не существует то создан с передаными данными
// Нужно быть осторожным с AutoInit и AutoReset (смотри дополнительные возможности)
entity.Put(new Position(x: 1, y: 1, z: 2));
```
- Основные операции:
```c#
var entity = MyEsc.Entity.New(
            new Name { Val = "Player" },
            new Velocity { Val = 1f },
            new Position { Val = Vector3.One }
);
 // Получить количество компонентов на сущности
int componentsCount = entity.ComponentsCount();

// Получить ref ссылку на компонент на чтение\запись
ref var velocity = ref entity.RefMut<Velocity>();
velocity.Val++;

// Получить ref ссылку на компонент только на чтение
ref readonly var readOnlyVelocity = ref entity.Ref<Velocity>();
//readOnlyVelocity.Value++;  -   ERROR

// Проверить наличие ВСЕХ указанных компонентов (методы перегрузки от 1-3 компонентов)
entity.HasAllOf<Position>();
entity.HasAllOf<Position, Velocity, Name>();

// Проверить наличие хотя бы одного указанного компонента (методы перегрузки от 2-3 компонентов)
entity.HasAnyOf<Position, Name>();
entity.HasAnyOf<Position, Velocity, Name>();

// Удалить компонент у сущности (методы перегрузки от 1-5 компонентов)
bool deleted = entity.Delete<Position>();  // deleted = true если компонент был удален, false если компонента не было изначально
bool deleted = entity.Delete<Position, Velocity, Name>();  // deleted = true если ВСЕ компоненты был удалены, false если хотя бы 1 компонента не было изначально

var entity2 = MyEsc.Entity.New<Name>();
// Скопировать указанные компоненты на другую сущность (методы перегрузки от 1-5 компонентов)
entity.CopyComponentsTo<Position, Velocity>(entity2);
```
</details>

### Tag
Тег - аналогичен компоненту, но не содержит никаких данных, служит для маркировки сущности  
 - Оптимизированное хранилище, не хранит массивы данных, не замедляет поиск по компонентам, позволяет создавать множество тегов
 - При удалении последнего компонента, Теги не учитываются и сущность удаляется
 - Дает возможность строить запросы поиска только по тегам
 - Представлен в виде пользовательской структуры без данных с маркер интерфейсом `ITag`

Пример:
```c#
public struct Unit : ITag { }
```

<details><summary>Использование</summary>

- Создание:
```c#
// Добавление тега на сущность (в DEBUG режиме будет ошибка если он уже существует на сущности) (методы перегрузки от 1-5 тегов)
entity.AddTag<Unit, Player>();

// Добавление тега на сущность если его еще нет
entity.TryAddTag<Unit>();
entity.TryAddTag<Unit>(out bool added); // перегрузка где added = true если тег новый
```
- Основные операции:
```c#
 // Получить количество тегов на сущности
int tagsCount = entity.TagsCount();

// Проверить наличие ВСЕХ тегов (методы перегрузки от 1-3 тегов)
entity.HasAllOfTags<Unit>();
entity.HasAllOfTags<Unit, Player>();

// Проверить наличие хотя бы одного тега (методы перегрузки от 2-3 тегов)
entity.HasAnyOfTags<Unit, Player>();

// Удалить тег у сущности (методы перегрузки от 1-5 тегов)
bool deleted = entity.DeleteTag<Unit>();  // deleted = true если тег был удален, false если тега не было изначально
bool deleted = entity.DeleteTag<Unit, Player>();  // deleted = true если ВСЕ теги был удалены, false если хотя бы 1 тега не было изначально
```
</details>

### Mask
Маска - аналогична тегу, но занимает лишь 1 бит памяти
- При удалении последнего компонента, Маски как и Теги не учитываются и сущность удаляется
- НЕ Дает возможность строить запросы только по маскам, может использоваться только как дополнительный критерий поиска
- Представлен в виде пользовательской структуры без данных с маркер интерфейсом `IMask`

Пример:
```c#
public struct Visible : IMask { }
```

<details><summary>Использование</summary>

- Создание:
```c#
// Добавление маски на сущность (методы перегрузки от 1-5 масок)
entity.SetMask<Flammable, Frozen, Visible>();
```
- Основные операции:
```c#
// Получить количество масок на сущности
int masksCount = entity.MasksCount();

// Проверить наличие ВСЕХ масок (методы перегрузки от 1-3 масок)
entity.HasAllOfMasks<Flammable>();
entity.HasAllOfMasks<Flammable, Frozen, Visible>();

// Проверить наличие хотя бы одной маски (методы перегрузки от 2-3 масок)
entity.HasAnyOfMasks<Flammable, Frozen, Visible>();

// Удалить маску у сущности (методы перегрузки от 1-5 масок)
entity.DeleteMask<Frozen>();
```
</details>

### WorldId
Тип-тег-идентификатор мира, служит для изоляции статических данных при создании разных миров в одном процессе
- Представлен в виде пользовательской структуры без данных с маркер интерфейсом `IWorldId` 

Пример:
```c#
public struct MainWorldId : IWorldId { }
public struct MiniGameWorldId : IWorldId { }
```

### Ecs
Точка входа в библиотеку, отвечающая за доступ, создание, инициализацию, работу и уничтожение данных мира
- Представлен в виде статического класса `Ecs<T>` параметризованного `IWorldId`
> ВАЖНО! Так как тип- идентификатор `IWorldId` определяет доступ к конкретному миру  
> Есть три способа работы с библиотекой:  

Первый способ - как есть через полное обращение (очень неудобно):
```c#
public struct MainWorldId : IWorldId { }

Ecs<MainWorldId>.CreateWorld(EcsConfig.Default());
Ecs<MainWorldId>.World.GetEntitiesCount();

var entity = Ecs<MainWorldId>.Entity.New<Position>();
```

Второй способ - чуть более удобный, использовать статические импорты или статические алиасы (придется писать в каждом файле)
```c#
using static FFS.Libraries.StaticEcs.Ecs<MainWorldId>;

public struct MainWorldId : IWorldId { }

CreateWorld(EcsConfig.Default());
World.GetEntitiesCount();

var entity = Entity.New<Position>();
```

Трейтий способ - самый удобный, использовать типы-алиасы в корневом неймспейсе (не требуется писать в каждом файле)  
Везде в примерах будет использован именно этот способ
```c#
public struct MainWorldId : IWorldId { }

public abstract class MyEsc : Ecs<MainWorldId> { }
public abstract class MyWorld : Ecs<MainWorldId>.World { }

MyEsc.CreateWorld(EcsConfig.Default());
MyWorld.GetEntitiesCount();

var entity = MyEsc.Entity.New<Position>();
```

<details><summary>Использование</summary>

```c#
// Определяем ID мира
public struct MainWorldId : IWorldId { }

// Регестрируем типы - алиасы
public abstract class MyEsc : Ecs<MainWorldId> { }
public abstract class MyWorld : Ecs<MainWorldId>.World { }

// Создание мира с дефолтной конфигурацие
MyEsc.CreateWorld(EcsConfig.Default());
// Или кастомной
MyEsc.CreateWorld(new() {
            BaseEntitiesCount = 256,        // Базовый размер массива сущностей при создания мира
            BaseDeletedEntitiesCount = 256, // Базовый размер массива удаленных сущностей при создания мира
            BaseComponentTypesCount = 64    // Базовый размер всех разновидностей типов компонентов (количество пулов под каждый тип)
            BaseMaskTypesCount = 64,        // Базовый размер всех разновидностей типов масок (количество пулов под каждый тип)
            BaseTagTypesCount = 64,         // Базовый размер всех разновидностей типов тегов (количество пулов под каждый тип)
            BaseComponentPoolCount = 128,   // Базовый размер массива данных компонентов определнного типа (может быть переопределнно для конкретного типа при явной регистрации)
            BaseTagPoolCount = 128,         // Базовый размер массива тегов определнного типа (может быть переопределнно для конкретного типа при явной регистрации)
        });

MyWorld.         // Доступ к миру для MainWorldId (ID мира)
MyEsc.Entity.    // Доступ к сущности для MainWorldId (ID мира)
MyEsc.Context.   // Доступ к контексту для MainWorldId (ID мира)
MyEsc.Components.// Доступ к компонентам для MainWorldId (ID мира)
MyEsc.Tags.      // Доступ к тегам для MainWorldId (ID мира)
MyEsc.Masks.     // Доступ к маскам для MainWorldId (ID мира)

// Инициализация мира
MyEsc.InitializeWorld();

// Уничтожение и очистка данных мира
MyEsc.DestroyWorld();

```
</details>

### World
Мир, содержит мета информацию сущностей, контролирует и менеджируют создание и удаление сущностей
- Представлен в виде статического класса `Ecs<IWorldId>.World`

<details><summary>Использование</summary>

- Создание:
```c#
// Создается только при вызове
MyEsc.CreateWorld(config);

// Инициализируется только при вызове
MyEsc.InitializeWorld();
```
- Основные операции:
```c#
// Явная регистрация типа компонента (По умолчанию регистрируется автоматически и лениво)
// Может быть полезоно при NativeAot
// Также для указания базового размера массива даных компонентов этого типа
// Также для получения динамического идентификатора типа компонента (раздел дополнительные возможности)
var positionComponentId = MyWorld.RegisterComponent<Position>(256);

// аналогично RegisterComponent но для тегов
var unitTagId = MyWorld.RegisterTag<Unit>(256);

// аналогично RegisterComponent но для масок
var visibleMaskId = MyWorld.RegisterMask<Visible>();

// true если мир инициализирован
bool initialized = MyWorld.IsInitialized();

// количество активных сущностей в мире
int entitiesCount = MyWorld.EntitiesCount();

// текущая емкость массива для сущностей
int entitiesCapacity = MyWorld.EntitiesCapacity();

// версия сущности
short entityVersion = MyWorld.EntityVersion(entity);

// Удалить сущность и все ее компоненты - аналогично entity.Destroy();
MyWorld.DeleteEntity(entity);

// Копировать все компоненты теги и маски с одной сущности на другую - аналогично entitySrc.CopyTo(entityTarget);
MyWorld.CopyEntityData(entitySrc, entityTarget);

// Клонировать сущность и все компоненты теги и маски - аналогично entity.Clone();
var clone = MyWorld.CloneEntity(entity);

// Получить строку со всей информацией о сущности - аналогично entity.ToPrettyStringEntity();
var str = MyWorld.ToPrettyStringEntity(entity);

```
</details>

### SystemsId
Тип-тег-идентификатор систем, служит для изоляции статических данных при создании групп систем в одном процессе
- Представлен в виде пользовательской структуры без данных с маркер интерфейсом `ISystemsId`

Пример:
```c#
public struct BaseSystemsId : ISystemsId { }
public struct FixedSystemsId : ISystemsId { }
public struct LateSystemsId : ISystemsId { }
```

### Systems
Системы, контролирует и менеджируют создание и запуск систем
- Представлен в виде статического класса `Systems<ISystemsId>`

<details><summary>Использование</summary>

```c#
// Системы существуют 3 видов и могут использоваться во всех комбинациях вместе или отдельно

// Система IInitSystem - метод Init() запускается один раз при инициализации MySystems.Initialize()
// Пример:
public struct SomeInitSystem : IInitSystem {
    public void Init() { }
}

// Система IUpdateSystem  - метод Update() запускается каждый раз при вызове MySystems.Update();
// Пример:
public struct SomeUpdateSystem : IUpdateSystem {
    public void Update() { }
}

// Система IDestroySystem - метод Destroy() запускается один раз при вызове MySystems.Destroy();
// Пример:
public struct SomeDestroySystem : IDestroySystem {
    public void Destroy() { }
}

 // Комбинированная система
 public struct SomeInitDestroySystem : IInitSystem, IDestroySystem {
     public void Init() { }
     public void Destroy() { }
 }

 // Комбинированная система
 public struct SomeComboSystem : IInitSystem, IUpdateSystem, IDestroySystem {
     public void Init() { }
     public void Update() { }
     public void Destroy() { }
 }
```

- Создание и операции:
```c#
// Определяем идентификатор систем
public struct MySystemsID : ISystemsId { }

// Определяем тип-алиас для удобного доступа к системам
public abstract class MySystems : Systems<MySystemsID> { }

// Здесь будет созданны структуры для систем
MySystems.Create();

// Добавление системы НЕ реализующей IUpdateSystem, то есть Init и\или Destroy системы
MySystems.AddCallOnceSystem<SomeInitSystem>();
MySystems.AddCallOnceSystem<SomeDestroySystem>();
MySystems.AddCallOnceSystem<SomeInitDestroySystem>();

// Добавление системы реализующей IUpdateSystem, с наличием любых имплементаций таких как Init или Destroy
MySystems.AddUpdateSystem<SomeComboSystem>();

// Важно! Системы запускаются в том порядке в котором зарегистрированны
// это значит что сначала будут запущены все Init системы в том порядке в котором добавлены
// затем в игровом цикле будут выполняться по порядку все Update системы
// затем по порядку вызовутся все системы типа Destroy при уничтожении мира

// Важно! Системы могут быть структурами или классами с пустым конструктором, и не инициализируются пользователем 
// (использование структур может существенно увеличить производительность для небольших систем)
// Они будут созданы в процессе регистрации и все дополнительные поля должны быть получены из контекста (Ecs.Context) или проинициализированны с помощью IInitSystem метода Init()

// Все это позволяет подключать системы пачками что может существенно увеличить производительность
// A также позволяет делать системы более атомарными (небольшими функциональными блоками)

// Добавление батча систем, каждая система может реализовывать любые типы систем но обязана иметь реализацию IUpdateSystem
// Ecs.SystemsBatch тип имеет перегрузки для разного количества систем
MySystems.AddBatchUpdateSystem<Ecs.SystemsBatch<
    SomeUpdateSystem1,
    SomeComboSystem1,
    SomeComboSystem2,
    SomeComboSystem3,
    SomeComboSystem4,
    SomeComboSystem5,
    SomeComboSystem
>>();

// Здесь будут вызваны все Init системы
MySystems.Initialize();

// Здесь будут вызваны все Update системы
MySystems.Update();

// Здесь будут вызваны все Destroy системы
MySystems.Destroy();
```
</details>

### Context
Контекст - альтернатива DI, простой механизм хранения и передачи пользовательских данных и сервисов в системы и другие методы
- Представлен в виде статического класса `Ecs<IWorldId>.Context<T>`

<details><summary>Использование</summary>

- Основные операции:
```c#
// Пользовательские классы и сервисы
public class UserService1 { }
public class UserService2 { }

// Добавление в контекст нужных обьектов, не обязательно добавлять в контекст обьекты до инициализации, в процессе работы систем также могут добавляться новые данные
// Важно помнить что если контекст используется в Init системах то данные туда должны быть переданы до Ecs.Initialize() или до вызова в цепочке вызовов конкретной Init системы 
// Важно! в контексте может храниться строго 1 обьект 1 типа - при установке чере метод Set повторно одного типа будет ошибка
MyEcs.Context<UserService1>.Set(new UserService1());
MyEcs.Context<UserService2>.Set(new UserService2());

// При вызове Replace указаный тип установится или заменится без ошибки 
MyEcs.Context<UserService2>.Replace(new UserService2());

// Проверить есть в контексте значение данного типа
bool has = MyEcs.Context<UserService2>.Has();

// Удалить значение из контекста
MyEcs.Context<UserService2>.Remove();

// Важно! пользователь сам заботится об очистке контекста если он больше не нужен или когда  уже мир удален, например в методе Destroy в системах
```
</details>

### Query
Запросы - механизм позволяющий осуществлять поиск сущностей и их компонентов в мире

<details><summary>Использование</summary>

Рассмотрим базовые возможности поиска сущностей в мире:
```c#
// Существует множество доступных вариантов запросов
// World.QueryEntities.For()\With() возвращает итератор сущностей подходящих под условие
// Для применение условий фильтрации компонентов доступны следующие типы:

// All - фильтрует сущности на наличие всех указанных компонентов (перегрузка от 1 до 8)
All<Types<Position, Direction, Velocity>> _all = default;
Single<Position> _single = default; // чуть более эффективный метод чем All<Types<Position>>
Double<Position, Velocity> _double = default; // чуть более эффективный метод чем All<Types<Position, Velocity>>

// AllAndNone - фильтрует сущности на наличие всех указанных компонентов первой группы и отсутсвие всех во второй (перегрузка от 1 до 8)
AllAndNone<Types<Position, Direction, Velocity>, Types<Name>> _allAndNone = default;

// None - фильтрует сущности на отсутсвие всех указанных компонентов (может использоваться только в составе других методов) (перегрузка от 1 до 8)
None<Types<Name>> _none = default;

// Any - фильтрует сущности на наличие любого из указанных компонентов (может использоваться только в составе других методов) (перегрузка от 1 до 8)
Any<Types<Position, Direction, Velocity>> _any = default;

// Аналоги для тегов
// TagAll - фильтрует сущности на наличие всех указанных тегов (перегрузка от 1 до 8)
TagAll<Tag<Unit, Player>> _all = default;
TagSingle<Unit> _single = default; // чуть более эффективный метод чем TagAll<Tag<Unit>>
TagDouble<Unit, Player> _double = default; // чуть более эффективный метод чем TagAll<Tag<Unit, Player>>

// AllAndNone - фильтрует сущности на наличие всех указанных тегов первой группы и отсутсвие всех во второй (перегрузка от 1 до 8)
TagAllAndNone<Tag<Unit>, Tag<Player>> _allAndNone = default;

// None - фильтрует сущности на отсутсвие всех указанных тегов (может использоваться только в составе других методов) (перегрузка от 1 до 8)
TagNone<Tag<Unit>> _none = default;

// Any - фильтрует сущности на наличие любого из указанных тегов (может использоваться только в составе других методов) (перегрузка от 1 до 8)
TagAny<Tag<Unit, Player>> _any = default;

// Аналоги для масок
// MaskAll - фильтрует сущности на наличие всех указанных тегов (может использоваться только в составе других методов) (перегрузка от 1 до 8)
MaskAll<Mask<Flammable, Frozen, Visible>> _all = default;
MaskSingle<Flammable> _single = default; // чуть более эффективный метод чем MaskAll<Mask<Flammable>>
MaskDouble<Flammable, Frozen> _double = default; // чуть более эффективный метод чем MaskAll<Mask<Flammable, Frozen>>

// AllAndNone - фильтрует сущности на наличие всех указанных тегов первой группы и отсутсвие всех во второй (может использоваться только в составе других методов)
MaskAllAndNone<Mask<Flammable, Frozen>, Mask<Visible>> _allAndNone = default;

// None - фильтрует сущности на отсутсвие всех указанных тегов (может использоваться только в составе других методов) (перегрузка от 1 до 8)
MaskNone<Mask<Frozen>> _none = default;

// Any - фильтрует сущности на наличие любого из указанных тегов (может использоваться только в составе других методов) (перегрузка от 1 до 8)
MaskAny<Mask<Flammable, Frozen, Visible>> _any = default;

// Все типы выше не требуют явной инициализации, не требуют кеширования, каждый из них занимает не больше 1-2 байт и может использоваться "на лету"


// Различные наборы методов фильтрации могут быть применины к методу World.QueryEntities.For() например:
// Вариант с 1 методом через дженерик
foreach (var entity in MyWorld.QueryEntities.For<All<Types<Position, Direction, Velocity>>>()) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}

// Вариант с 1 методом через значение
var all = default(All<Types<Position, Direction, Velocity>>);
foreach (var entity in MyWorld.QueryEntities.For(all)) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}

// Вариант с 3 методами  через дженерик
foreach (var entity in MyWorld.QueryEntities.For<
             All<Types<Position, Velocity, Name>>,
             AllAndNone<Types<Position, Direction, Velocity>, Types<Name>>,
             None<Types<Name>>>()) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}

// Вариант с 3 методами  через значение
All<Types<Position, Direction, Velocity>> all2 = default;
AllAndNone<Types<Position, Direction, Velocity>, Types<Name>> allAndNone2 = default;
None<Types<Name>> none2 = default;
foreach (var entity in MyWorld.QueryEntities.For(all2, allAndNone2, none2)) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}

// Альтернативный вариант с 3 методами  через значение
var all3 = Types<Position, Direction, Velocity>.All();
var allAndNone3 = Types<Position, Direction, Velocity>.AllAndNone(default(Types<Name>));
var none3 = Types<Name>.None();
foreach (var entity in MyWorld.QueryEntities.For(all3, allAndNone3, none3)) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}


// Также все методы фильтрации могут быть сгруппированны в тип With
// который может применяться к методу World.QueryEntities.With() например:

// Способ 1 через дженерик
foreach (var entity in MyWorld.QueryEntities.With<With<
             All<Types<Position, Velocity, Name>>,
             AllAndNone<Types<Position, Direction, Velocity>, Types<Name>>,
             None<Types<Name>>,
             Any<Types<Position, Direction, Velocity>>
         >>()) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}

// Способ 2 через значения
With<
    All<Types<Position, Velocity, Name>>,
    AllAndNone<Types<Position, Direction, Velocity>, Types<Name>>,
    None<Types<Name>>,
    Any<Types<Position, Direction, Velocity>>
> with = default;
foreach (var entity in MyWorld.QueryEntities.With(with)) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}

// Способ 3 через значения альтернативный
var with2 = With.Create(
    default(All<Types<Position, Velocity, Name>>),
    default(AllAndNone<Types<Position, Direction, Velocity>, Types<Name>>),
    default(None<Types<Name>>),
    default(Any<Types<Position, Direction, Velocity>>)
);
foreach (var entity in MyWorld.QueryEntities.With(with2)) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}

// Способ 4 через значения альтернативный
var with3 = With.Create(
    Types<Position, Velocity, Name>.All(),
    Types<Position, Direction, Velocity>.AllAndNone(default(Types<Name>)),
    Types<Name>.None(),
    Types<Position, Direction, Velocity>.Any()
);
foreach (var entity in MyWorld.QueryEntities.With(with3)) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}
```

Рассмотрим дополнительные возможности поиска сущностей в мире:
```c#
// World.QueryComponents.For()\With() возвращает итератор сущностей подходящих под условие cразу с компонентами 


// Вариант 1 когда нужно пройтись по всем компонентам одного типа
// (очень быстрый, может использоваться для очень простых операций для которых не нужная сущность или другие компоненты)
foreach (ref var position in MyWorld.QueryComponents.For<Position>()) {
    position.Val += Vector3.UnitX;
}

// Вариант 2 с указанием делегата и сразу получением нужных компонентов, может быть указано от 1 до 8 типов компонентов
MyWorld.QueryComponents.For<Position, Velocity, Name>((Ecs.Entity entity, ref Position position, ref Velocity velocity, ref Name name) => {
    position.Val *= velocity.Val;
});

// можно убрать дженерики, так как они выводятся из типа переданной функции
MyWorld.QueryComponents.For((Ecs.Entity entity, ref Position position, ref Velocity velocity, ref Name name) => {
    position.Val *= velocity.Val;
});

// можно добавить ограничение static для делегата для того чтобы гарантировать что данный делегат не будет аллоцироваться каждый раз
// в совокупности с Ecs.Context дает возможность удобного и производительного кода без создания замыканий в делегате
MyWorld.QueryComponents.For(static (Ecs.Entity entity, ref Position position, ref Velocity velocity, ref Name name) => {
    position.Val *= velocity.Val;
});

// Также можно использовать WithAdds аналогичный With из прошлого примера но разрешающий указания только вторичных методов фильтрации (такиех как None, Any) для дополнительной фильтрации сущностей
// Стоит заметить что компоненты которые указаны в делегате расцениваются как фильтр All
// то есть WithAdds лишь дополнят фильтрации и не требует указания используемых компонентов

WithAdds<
    None<Types<Direction>>,
    Any<Types<Position, Direction, Velocity>>
> with = default;

MyWorld.QueryComponents.With(with).For(static (Ecs.Entity entity, ref Position position, ref Velocity velocity, ref Name name) => {
    position.Val *= velocity.Val;
});

// или так
MyWorld.QueryComponents.With<WithAdds<
    None<Types<Direction>>,
    Any<Types<Position, Direction, Velocity>>
>>().For(static (Ecs.Entity entity, ref Position position, ref Velocity velocity, ref Name name) => {
    position.Val *= velocity.Val;
});
```

Рассмотрим особые возможности поиска сущностей в мире:
```c#
// Запросы с передачей структуры-функции 
// может использоваться для оптимизации или передачи состояния в стракт или для вынесения логики

// Определим структуру-функцию которой можем заменить делегат
// Она должна реализовывать интерфейс IQueryFunction с указанием от 1-8 компонентов
readonly struct StructFunction : Ecs.IQueryFunction<Position, Velocity, Name> {
    public void Run(Ecs.Entity entity, ref Position position, ref Velocity velocity, ref Name name) {
        position.Val *= velocity.Val;
    }
}

// Вариант 1 с передачей через дженерик
MyWorld.QueryComponents.For<Position, Velocity, Name, StructFunction>();

// Вариант 1 с передачей через значение
MyWorld.QueryComponents.For<Position, Velocity, Name, StructFunction>(new StructFunction());

// Вариант 2 с With через дженерик
MyWorld.QueryComponents.With<WithAdds<
    None<Types<Direction>>,
    Any<Types<Position, Direction, Velocity>>
>>().For<Position, Velocity, Name, StructFunction>();

// Вариант 2 с With через значение
WithAdds<
    None<Types<Direction>>,
    Any<Types<Position, Direction, Velocity>>
> with = default;
MyWorld.QueryComponents.With(with).For<Position, Velocity, Name, StructFunction>();

// Также возможно комбинировать систему и IQueryFunction, например:
// это может улучшить восприятия кода и увеличить производительность + это позволяет обращаться в нестатическим членам системы
public struct SomeFunctionSystem : IInitSystem, IUpdateSystem, Ecs.IQueryFunction<Position, Velocity, Name> {
    private UserService1 _userService1;
    
    WithAdds<
        None<Types<Direction>>,
        Any<Types<Position, Direction, Velocity>>
    > with;
    
    public void Init() {
        _userService1 = Ecs.Context<UserService1>.Get();
    }
    
   public void Update() {
       MyWorld.QueryComponents
            .With(with)
            .For<Position, Velocity, Name, SomeFunctionSystem>(ref this);
   }
    
    public void Run(Ecs.Entity entity, ref Position position, ref Velocity velocity, ref Name name) {
        position.Val *= velocity.Val;
        _userService1.CallSomeMethod(name.Val);
    }
}
```

</details>

# Дополнительные возможности
### Идентификаторы компонентов
В случае когда проект очень большой или наоборот маленький и объем компилируемого кода важен:  
Такие вещи как = типизированные Query, и сахарные методы работы с сущностью, могут раздувать компилируемый код за счет мономорфизации дженерик типов в структурах и методах.
Чтобы этого избежать, реализован механиз динамических идентификаторов для компонентов, тегов и масок - которые позволяют использовать их вместо параметров типов  
Как это работает:
```csharp
// После вызова Ecs.CreateWorld(EcsConfig.Default());
// Можно явно зарегистрировать типы компонентов и получить структуру содержащую идентифкатор типа
ComponentDynId positionId = MyWorld.RegisterComponent<Position>();
TagDynId unitTagId = MyWorld.RegisterTag<Unit>();
MaskDynId frozenMaskId = MyWorld.RegisterMask<Frozen>();

// Альтернативно можно после инициализации мира в любой момент получить данные идентификаторы след образом:
ComponentDynId positionId = Ecs.Components.GetDynamicId<Position>();
TagDynId unitTagId = Ecs.Tags.GetDynamicId<Unit>();
MaskDynId frozenMaskId = Ecs.Masks.GetDynamicId<Frozen>();

// Данные идентификаторы можно сохранить любым удобным способом и использовать в операциях c сущностью или Query
// Существую перегрузки для большинства методов работы с сущностью для данных идентификаторов
// Пример для сущностей
entity.Add(positionId);
entity.TryAdd(positionId, VelocityId, nameId);
entity.Delete(positionId, VelocityId, nameId);
entity.AddTag(unitTagId);
entity.SetMask(frozenMaskId);

// Пример для Query
// Существуют перегрузки типы Types1-8, Tag1-8, Mask1-8 а также общие реализаци для расширений такие как TypesBox, TypesArray и тд
// Данные перегрузки содержат данные идентификаторов, а не пустые как аналоги с дженериками
// это значит что их желательно не создавать на лету а кешировать для лучшей производительности

var all = new Types3(positionId, VelocityId, nameId).All();
foreach (var entity in MyWorld.QueryEntities.For(all)) {
    //..
}

var with = With.Create(
    new Types3(positionId, VelocityId, nameId).All(),
    new Types1(scaleId).None(),
    new Tag2(playerTagId, unitTagId).Any(),
    new Mask1(frozenMaskId).AllAndNone(new Mask1(flammableMaskId))
);
foreach (var entity in MyWorld.QueryEntities.With(with)) {
    //..
}

// Также это механизм позволяет использовать данные ключи в логике игры
// Например когда тип создаваемого компонента меняется в зависимости от условий
// Важно! помнить что данные идентификаторы динамические - это значит что нет гарантий что от запуска к запуску они будут одинаковые
// значит их нельзя сериализовывать или использовать подобным образом
```
### Авто обработчики
По умолчанию при добавлении или удалении компонента данные заполняются дефолтным значение, а при копировании компонент полностью копируется  
Чтобы установить свою логику дефолтной инициализации и сброса компонента можно воспользоваться обработчиками

**AutoInit** - заменяет поведение при создании компонента через метод Add
```csharp
MyEcs.Create(EcsConfig.Default());
//...
MyEcs.Components.AutoHandlers<Position>.SetAutoInit(static (ref Position position) => position.Val = Vector3.One);
//...
MyEcs.Initialize();
```

**AutoReset** - заменяет поведение при удалении компонента через метод Delete
```csharp
MyEcs.Create(EcsConfig.Default());
//...
MyEcs.Components.AutoHandlers<Position>.SetAutoInit(static (ref Position position) => position.Val = Vector3.One);
//...
MyEcs.Initialize();
```

**AutoCopy** - заменяет поведение при копировании компонента
```csharp
MyEcs.Create(EcsConfig.Default());
//...
MyEcs.Components.AutoHandlers<Position>.SetAutoCopy(static (ref Position src, ref Position dst) => dst.Val = src.Val);
//...
MyEcs.Initialize();
```

> **Важно!** Стоит учитывать что создание сущности с установкой значения или добавления компонента через метод Put  
> полностью заменяют данные в компоненте, в обход установленных авто обработчиков

### События
**WIP**

### Отношения
**WIP**

# Специальные типы
### Components
**WIP**

### ComponentsPool
**WIP**

### Tags
**WIP**

### TagsPool
**WIP**

### Masks
**WIP**

### MasksPool
**WIP**


# Производительность
**WIP**

# Интеграция в движки
### Unity
Пример:
```csharp
using System;
using UnityEngine;
using FFS.Libraries.StaticEcs;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public struct MyWorldId : IWorldId { }
public struct MySystemsId : ISystemsId { }

public abstract class MyEcs : Ecs<MyWorldId> { }
public abstract class MyWorld : MyEcs.World { }
public abstract class MySystems : Systems<MySystemsId> { }

public struct Position : IComponent {
    public Transform Value;
}

public struct Direction : IComponent {
    public Vector3 Value;
}

public struct Velocity : IComponent {
    public float Value;
}

[Serializable]
public struct SceneData {
    public GameObject EntityPrefab;
}

public struct CreateRandomEntities : IInitSystem {
    public void Init() {
        for (var i = 0; i < 100; i++) {
            var gameObject = Object.Instantiate(MyEcs.Context<SceneData>.Get().EntityPrefab);
            gameObject.transform.position = new Vector3(Random.Range(0, 50), 0, Random.Range(0, 50));
            MyEcs.Entity.New(
                new Position { Value = gameObject.transform },
                new Direction { Value = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)) },
                new Velocity { Value = 2f });
        }
    }
}

public struct UpdatePositions : IUpdateSystem {
    public void Update() {
        MyWorld.QueryComponents.For((MyEcs.Entity entity, ref Position position, ref Velocity velocity, ref Direction direction) => {
            position.Value.position += direction.Value * (Time.deltaTime * velocity.Value);
        });
    }
}

public class Main : MonoBehaviour {
    public SceneData sceneData;
    
    void Start() {
        MyEcs.CreateWorld(EcsConfig.Default());
        MyEcs.InitializeWorld();
        
        MyEcs.Context<SceneData>.Set(sceneData);
        
        MySystems.Create();
        
        MySystems.AddCallOnceSystem<CreateRandomEntities>();
        MySystems.AddUpdateSystem<UpdatePositions>();
        
        MySystems.Initialize();
    }

    void Update() {
        MySystems.Update();
    }

    private void OnDestroy() {
        MySystems.Destroy();
        MyEcs.DestroyWorld();
    }
}
```

# Вопрос-ответ
**WIP**

# Лицензия
[MIT license](./LICENSE)
