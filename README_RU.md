![Version](https://img.shields.io/badge/version-0.9.31-blue.svg?style=for-the-badge)

### ЯЗЫК
[RU](./README_RU.md)
[EN](./README.md)
___
### 🚀 **[Benchmarks](./Benchmark.md)** 🚀
### ⚙️ **[Unity module](https://github.com/Felid-Force-Studios/StaticEcs-Unity)** ⚙️
 
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
    * [StandardComponent](#standardComponent)
    * [Tag](#tag)
    * [Mask](#mask)
    * [WorldType](#WorldType)
    * [Ecs](#ecs)
    * [World](#world)
    * [Systems](#systems)
    * [Context](#context)
    * [Query](#query)
* [Дополнительные возможности](#дополнительные-возможности)
    * [Идентификаторы компонентов](#идентификаторы-компонентов)
    * [Авто обработчики](#авто-обработчики)
    * [События](#события)
    * [Отношения](#отношения)
    * [Директивы компилятора](#директивы-компилятора)
* [Производительность](#производительность)
* [Интеграция в движки](#интеграция-в-движки)
    * [Unity](#unity)
* [Вопрос-ответ](#вопрос-ответ)
* [Лицензия](#лицензия)


# Контакты
* [Telegram](https://t.me/felid_force_studios)
# Установка
* ### В виде исходников
  Со страцины релизов или как архив из нужной ветки. В ветке `master` стабильная проверенная версия
* ### Установка для Unity
  Как git модуль `https://github.com/Felid-Force-Studios/StaticEcs.git` в Unity PackageManager или добавления в `Packages/manifest.json`:


# Быстрый старт
```csharp
using FFS.Libraries.StaticEcs;
// Определяем компоненты
public struct Position : IComponent { public Vector3 Val; }
public struct Velocity : IComponent { public float Val; }

// Определяем тип мира
public struct MyWorldType : IWorldType { }

// Определяем типы-алиасы для удобного доступа к типам библиотеки
public abstract class MyEcs : Ecs<MyWorldType> { }
public abstract class MyWorld : MyEcs.World { }

// Определяем тип систем
public struct MySystemsType : ISystemsType { }

// Определяем тип-алиас для удобного доступа к системам
public abstract class MySystems : MyEcs.Systems<MySystemsType> { }

// Определояем системы
public readonly struct VelocitySystem : IUpdateSystem {
    public void Update() {
        foreach (var entity in MyWorld.QueryEntities.For<All<Position, Velocity>>()) {
            entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
        }
    }
}

public class Program {
    public static void Main() {
        // Создаем данные мира
        MyEcs.Create(EcsConfig.Default());
        
        // Регестрируем компоненты
        MyWorld.RegisterComponentType<Position>();
        MyWorld.RegisterComponentType<Velocity>();
        
        // Инициализацируем мир
        MyEcs.Initialize();
        
        // Создаем системы
        MySystems.Create();
        MySystems.AddUpdate(new VelocitySystem());

        // Инициализацируем системы
        MySystems.Initialize();

        // Создание сущности
        var entity = MyEcs.Entity.New(
            new Velocity { Val = 1f },
            new Position { Val = Vector3.One }
        );
        // Обновление всех систем - вызывается в каждом кадре
        MySystems.Update();
        // Уничтожение систем
        MySystems.Destroy();
        // Уничтожение мира и очистка всех данных
        MyEcs.Destroy();
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

**ВАЖНО** ❗️  
По умолчанию сущность может быть создана и существовать без компонентов, также при удалении последнего компонента не удаляется  
Если требуется переопределить это поведение необходимо указать директиву компилятора `FFS_ECS_LIFECYCLE_ENTITY`  
Дополнительная информация: [Директивы компилятора](#директивы-компилятора)

<details><summary><u><b>Использование 👇</b></u></summary>

- Создание:
```csharp
// Создание одной сущности

// Способ 1 - создание "пустой" сущности
var entity = MyEcs.Entity.New();

// Способ 2 - с указанием типа компонента (методы перегрузки от 1-5 компонентов)
var entity = MyEcs.Entity.New<Position>();
var entity = MyEcs.Entity.New<Position, Velocity, Name>();

// Способ 3 - с указанием значения компонента (методы перегрузки от 1-5 компонентов)
var entity = MyEcs.Entity.New(new Position(x: 1, y: 1, z: 2));
var entity = MyEcs.Entity.New(
            new Name { Val = "SomeName" },
            new Velocity { Val = 1f },
            new Position { Val = Vector3.One }
);

// Создание множества сущностей
// Способ 1 - с указанием типа компонента (методы перегрузки от 1-5 компонентов)
int count = 100;
MyEcs.Entity.NewOnes<Position>(count);

// Способ 2 - с указанием типа компонента (методы перегрузки от 1-5 компонентов) + делегата инициализации каждой сущности
int count = 100;
MyEcs.Entity.NewOnes<Position>(count, static entity => {
    // some init logic for each entity
});

// Способ 3 - с указанием значения компонента (методы перегрузки от 1-5 компонентов)
int count = 100;
MyEcs.Entity.NewOnes(count, new Position(x: 1, y: 1, z: 2));

// Способ 4 - с указанием значения компонента (методы перегрузки от 1-5 компонентов) + делегата инициализации каждой сущности
int count = 100;
MyEcs.Entity.NewOnes(count, new Position(x: 1, y: 1, z: 2), static entity => {
    // some init logic for each entity
});
```

- Основные операции:
```csharp
var entity = MyEcs.Entity.New(
            new Name { Val = "SomeName" },
            new Velocity { Val = 1f },
            new Position { Val = Vector3.One }
);

bool actual = entity.IsActual();         // Проверить не удалена ли сущность в мире
short version = entity.Version();        // Получить версию сущности
var clone = entity.Clone();              // Клонировать сущность и все компоненты, теги, маски
entity.Destroy();                        // Удалить сущность и все компоненты, теги, маски

var entity2 = MyEcs.Entity.New<Name>();
clone.CopyTo(entity2);                   // Копировать все компоненты, теги, маски в указанную сущность

var entity3 = MyEcs.Entity.New<Name>();
entity2.MoveTo(entity3);                 // Перенести все компоненты в указанную сущность и удалить текущую

PackedEntity packed = entity3.Pack();    // Упаковать сущность с мета информацией о версии для передачи

var str = entity3.ToPrettyString();      // Получить строку со всей информацией о сущности
```
</details>

### PackedEntity
Упакованая сущность - хранит мета информацию сущности, служит для безопасной передачи сущности (например в событиях, компонентах и тд)  
> сущность это просто id, упакованая сущность это id + version  
> просто по id невозможно определить та самая эта сущность что сейчас в мире под этим идентификатором или нет, можно только вместе с версией, для этого упакованая версия
 - Представлена в виде структуры размером 8 байт

<details><summary><u><b>Использование 👇</b></u></summary>

- Создание:
```csharp
// Создание возможно только через незапакованную сущность
PackedEntity packedEntity = entity.Pack();
```
- Основные операции:
```csharp
PackedEntity packedEntity = entity.Pack();
// Попытаться распаковать сущность в мире идентификатор которого указан через параметр типа, возвращает true если сущность успешно распакована, в out распакованя сущность
if (packedEntity.TryUnpack<WorldType>(out var unpackedEntity)) {
    // ...
}

PackedEntity packedEntity2 = entity.Pack();
bool equals = packedEntity.Equals(packedEntity2);     // Проверить идентичность упавкованных сущностей
```
</details>

### Component
Компонент - наделяет сущность свойствами
 - Дает возможность строить запросы поиска только по компонентам
 - Представлен в виде пользовательской структуры с маркер интерфейсом `IComponent`  
 - Представлен в виде struct исключительно по соображениям производительности

Пример:
```c#
public struct Position : IComponent {
    public Vector3 Value;
}
```

**ВАЖНО** ❗️  
Требуется регистрация в мире между созданием и инициализацией  

Пример:
```c#
MyEcs.Create(EcsConfig.Default());
//...
MyEcs.World.RegisterComponentType<Position>();
//...
MyEcs.Initialize();
```

<details><summary><u><b>Использование 👇</b></u></summary>

- Создание:
```c#
// Способ 1 - при создании сущности (аналогично методу Add())
var entity = MyEcs.Entity.New<Position>();

// Или через значение  (аналогично методу Put())
// Нужно быть осторожным с AutoInit и AutoReset (смотри дополнительные возможности)
var entity = MyEcs.Entity.New(new Position(x: 1, y: 1, z: 2));

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
var entity = MyEcs.Entity.New(
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

// Удалить компонент у сущности (в DEBUG режиме будет ошибка если компонент не существует на сущности,
// в релизе нельзя использовать если нет гарантии что компонент присутствует) (методы перегрузки от 1-5 компонентов)
entity.Delete<Position>();
entity.Delete<Position, Velocity, Name>();

// Удалить компонент у сущности если он есть (методы перегрузки от 1-5 компонентов)
bool deleted = entity.TryDelete<Position>();  // deleted = true если компонент был удален, false если компонента не было изначально
bool deleted = entity.TryDelete<Position, Velocity, Name>();  // deleted = true если ВСЕ компоненты был удалены, false если хотя бы 1 компонента не было изначально

var entity2 = MyEcs.Entity.New<Name>();
// Скопировать указанные компоненты на другую сущность (методы перегрузки от 1-5 компонентов)
entity.CopyComponentsTo<Position, Velocity>(entity2);
```
</details>

### StandardComponent
Стандартный компонент - стандартные свойства сущности, присутствует на каждой создаваемой сущности по умолчанию  
> Следует использовать в случаях когда ВСЕ сущности в мире должны содержать компоненты какого либо типа  
> например если компонент позиции должен быть на каждой сущности без исключения, стоит использовать стандартный компонент  
> так как скорость доступа выше, и не будет дополнительных затрат по памяти
> 
> Также может быть использован для небольших компонентов размером 1-8 байт, если не требуется строить логику на базе наличия или отсутсвия компонента
> 
> Например внутреняя версия сущности `entity.Version()` является стандартным компонентом
- Оптимизированное хранилище и прямой доступ к данным по идентификатору сущности
- Не может быть удален, только изменен
- Не учавствует в запросах, так как присутствует на всех сущностях
- Представлен в виде пользовательской структуры с маркер интерфейсом `IStandardComponent`

Пример:
```c#
public struct EnitiyType : IStandardComponent {
    public int Val;
}
```

**ВАЖНО** ❗️  
Требуется регистрация в мире между созданием и инициализацией

Пример:
```c#
MyEcs.Create(EcsConfig.Default());
//...
MyEcs.World.RegisterStandardComponentType<EnitiyType>();
//...
MyEcs.Initialize();
```

**ВАЖНО** ❗️  
Если требуется автоматическая инициализация при создании сущности или автоматический сброс при удалении сущности  
необходимо явно зарегестрировать обработчики

Пример:
```c#
public struct EnitiyType : IStandardComponent {
    public int Val;
    
    public void Init() {
        Val = -1;
    }
    
    public void Reset() {
        Val = -1;
    }
    
    public void CopyTo(ref EnitiyType dst) {
        dst.Val = Val;
    }
}

MyEcs.Create(EcsConfig.Default());
//...
MyEcs.World.RegisterStandardComponentType<EnitiyType>(
                autoInit: static (ref EnitiyType component) => component.Init(), // При создании сущности будет вызвана данная функция 
                autoReset: static (ref EnitiyType component) => component.Reset(), // При уничтожении сущности будет вызвана данная функция  
                autoCopy: static (ref EnitiyType src, ref EnitiyType dst) => src.CopyTo(ref dst), // При копировании стандартных компонентов будет вызвана данная сущности вместо простого копирования
            );

//...
MyEcs.Initialize();
```

<details><summary><u><b>Использование 👇</b></u></summary>

- Основные операции:
```c#
 // Получить количество стандартных компонентов на сущности
int standardComponentsCount = entity.StandardComponentsCount();

// Получить ref ссылку на стандартный компонент на чтение\запись
ref var enitiyType = ref entity.RefMutStandard<EnitiyType>();
enitiyType.Val = 123;

// Получить ref ссылку на стандартный компонент только на чтение
ref readonly var readOnlyEnitiyType = ref entity.RefStandard<EnitiyType>();
//readOnlyEnitiyType.Val = 123;  -   ERROR

var entity2 = MyEcs.Entity.New<SomeComponent>();
// Скопировать указанные стандартные компоненты на другую сущность (методы перегрузки от 1-5 компонентов)
entity.CopyStandardComponentsTo<EnitiyType>(entity2);
```
</details>

### Tag
Тег - аналогичен компоненту, но не содержит никаких данных, служит для маркировки сущности  
 - Оптимизированное хранилище, не хранит массивы данных, не замедляет поиск по компонентам, позволяет создавать множество тегов
 - Дает возможность строить запросы поиска только по тегам
 - Представлен в виде пользовательской структуры без данных с маркер интерфейсом `ITag`

Пример:
```c#
public struct Unit : ITag { }
```

**ВАЖНО** ❗️  
Требуется регистрация в мире между созданием и инициализацией

Пример:
```c#
MyEcs.Create(EcsConfig.Default());
//...
MyEcs.World.RegisterTagType<Unit>();
//...
MyEcs.Initialize();
```

<details><summary><u><b>Использование 👇</b></u></summary>

- Создание:
```c#
// Добавление тега на сущность (в DEBUG режиме будет ошибка если он уже существует на сущности) (методы перегрузки от 1-5 тегов)
entity.SetTag<Unit, Player>();
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

// Удалить тег у сущности (в DEBUG режиме будет ошибка если тега нет, 
// в релизе нельзя использовать если нет гарантии что тег присутствует) (методы перегрузки от 1-5 тегов)
entity.DeleteTag<Unit>();
entity.DeleteTag<Unit, Player>();

// Удалить тег у сущности если он есть (методы перегрузки от 1-5 тегов)
bool deleted = entity.TryDeleteTag<Unit>();  // deleted = true если тег был удален, false если тега не было изначально
bool deleted = entity.TryDeleteTag<Unit, Player>();  // deleted = true если ВСЕ теги был удалены, false если хотя бы 1 тега не было изначально
```
</details>

### Mask
Маска - аналогична тегу, но занимает лишь 1 бит памяти
- НЕ Дает возможность строить запросы только по маскам, может использоваться только как дополнительный критерий поиска
- Представлен в виде пользовательской структуры без данных с маркер интерфейсом `IMask`

Пример:
```c#
public struct Visible : IMask { }
```

**ВАЖНО** ❗️  
Требуется регистрация в мире между созданием и инициализацией

Пример:
```c#
MyEcs.Create(EcsConfig.Default());
//...
MyEcs.World.RegisterMaskType<Visible>();
//...
MyEcs.Initialize();
```

<details><summary><u><b>Использование 👇</b></u></summary>

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

// Удалить маску у сущности (В DEBUG режиме будет ошибка если сущности нет, 
// в релизе нельзя использовать если нет гарантии что маска присутствует) (методы перегрузки от 1-5 масок)
entity.DeleteMask<Frozen>();

// Удалить маску у сущности если она существует (методы перегрузки от 1-5 масок)
var deleted = entity.TryDeleteMask<Frozen>();
```
</details>

### WorldType
Тип-тег-идентификатор мира, служит для изоляции статических данных при создании разных миров в одном процессе
- Представлен в виде пользовательской структуры без данных с маркер интерфейсом `IWorldType` 

Пример:
```c#
public struct MainWorldType : IWorldType { }
public struct MiniGameWorldType : IWorldType { }
```

### Ecs
Точка входа в библиотеку, отвечающая за доступ, создание, инициализацию, работу и уничтожение данных мира
- Представлен в виде статического класса `Ecs<T>` параметризованного `IWorldType`
> ВАЖНО! Так как тип- идентификатор `IWorldType` определяет доступ к конкретному миру  
> Есть три способа работы с библиотекой:  

Первый способ - как есть через полное обращение (очень неудобно):
```c#
public struct MainWorldType : IWorldType { }

Ecs<MainWorldType>.Create(EcsConfig.Default());
Ecs<MainWorldType>.World.EntitiesCount();

var entity = Ecs<MainWorldType>.Entity.New<Position>();
```

Второй способ - чуть более удобный, использовать статические импорты или статические алиасы (придется писать в каждом файле)
```c#
using static FFS.Libraries.StaticEcs.Ecs<MainWorldType>;

public struct MainWorldType : IWorldType { }

Create(EcsConfig.Default());
World.EntitiesCount();

var entity = Entity.New<Position>();
```

Трейтий способ - самый удобный, использовать типы-алиасы в корневом неймспейсе (не требуется писать в каждом файле)  
Везде в примерах будет использован именно этот способ
```c#
public struct MainWorldType : IWorldType { }

public abstract class MyEcs : Ecs<MainWorldType> { }
public abstract class MyWorld : Ecs<MainWorldType>.World { }

MyEcs.Create(EcsConfig.Default());
MyWorld.EntitiesCount();

var entity = MyEcs.Entity.New<Position>();
```

<details><summary><u><b>Использование 👇</b></u></summary>

```c#
// Определяем ID мира
public struct MainWorldType : IWorldType { }

// Регестрируем типы - алиасы
public abstract class MyEcs : Ecs<MainWorldType> { }
public abstract class MyWorld : MyEcs.World { }

// Создание мира с дефолтной конфигурацие
MyEcs.Create(EcsConfig.Default());
// Или кастомной
MyEcs.Create(new() {
            BaseEntitiesCount = 256,        // Базовый размер массива сущностей при создания мира
            BaseDeletedEntitiesCount = 256, // Базовый размер массива удаленных сущностей при создания мира
            BaseComponentTypesCount = 64    // Базовый размер всех разновидностей типов компонентов (количество пулов под каждый тип)
            BaseMaskTypesCount = 64,        // Базовый размер всех разновидностей типов масок (количество пулов под каждый тип)
            BaseTagTypesCount = 64,         // Базовый размер всех разновидностей типов тегов (количество пулов под каждый тип)
            BaseComponentPoolCount = 128,   // Базовый размер массива данных компонентов определнного типа (может быть переопределнно для конкретного типа при явной регистрации)
            BaseTagPoolCount = 128,         // Базовый размер массива тегов определнного типа (может быть переопределнно для конкретного типа при явной регистрации)
        });

MyWorld.         // Доступ к миру для MainWorldType (ID мира)
MyEcs.Entity.    // Доступ к сущности для MainWorldType (ID мира)
MyEcs.Context.   // Доступ к контексту для MainWorldType (ID мира)
MyEcs.Components.// Доступ к компонентам для MainWorldType (ID мира)
MyEcs.Tags.      // Доступ к тегам для MainWorldType (ID мира)
MyEcs.Masks.     // Доступ к маскам для MainWorldType (ID мира)

// Инициализация мира
MyEcs.Initialize();

// Уничтожение и очистка данных мира
MyEcs.Destroy();

```
</details>

### World
Мир, содержит мета информацию сущностей, контролирует и менеджируют создание и удаление сущностей
- Представлен в виде статического класса `Ecs<IWorldType>.World`

<details><summary><u><b>Использование 👇</b></u></summary>

- Создание:
```c#
// Создается только при вызове
MyEcs.Create(config);

// Инициализируется только при вызове
MyEcs.Initialize();
```
- Основные операции:
```c#
// При регистрации компонента возможно указать базовой размер массива даных компонентов этого типа
// Также возвращается динамическй идентификатор типа компонента (раздел дополнительные возможности)
var positionComponentId = MyWorld.RegisterComponentType<Position>(256);

// аналогично RegisterComponentType, но для тегов
var unitTagId = MyWorld.RegisterTagType<Unit>(256);

// аналогично RegisterComponentType, но для масок
var visibleMaskId = MyWorld.RegisterMaskType<Visible>();

// true если мир инициализирован
bool initialized = MyWorld.IsInitialized();

// количество активных сущностей в мире
int entitiesCount = MyWorld.EntitiesCount();

// текущая емкость массива для сущностей
int entitiesCapacity = MyWorld.EntitiesCapacity();

// версия сущности
short entityVersion = MyWorld.EntityVersion(entity);

// Удалить сущность и все ее компоненты - аналогично entity.Destroy();
MyWorld.DestroyEntity(entity);

// Копировать все компоненты теги и маски с одной сущности на другую - аналогично entitySrc.CopyTo(entityTarget);
MyWorld.CopyEntityData(entitySrc, entityTarget);

// Клонировать сущность и все компоненты теги и маски - аналогично entity.Clone();
var clone = MyWorld.CloneEntity(entity);

// Получить строку со всей информацией о сущности - аналогично entity.ToPrettyStringEntity();
var str = MyWorld.ToPrettyStringEntity(entity);

```
</details>

### SystemsType
Тип-тег-идентификатор систем, служит для изоляции статических данных при создании групп систем в одном процессе
- Представлен в виде пользовательской структуры без данных с маркер интерфейсом `ISystemsType`

Пример:
```c#
public struct BaseSystemsType : ISystemsType { }
public struct FixedSystemsType : ISystemsType { }
public struct LateSystemsType : ISystemsType { }
```

### Systems
Системы, контролирует и менеджируют создание и запуск систем
- Представлен в виде статического класса `Systems<ISystemsType>`

<details><summary><u><b>Использование 👇</b></u></summary>

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
public struct MySystemsType : ISystemsType { }

// Определяем тип-алиас для удобного доступа к системам
public abstract class MySystems : MyEcs.Systems<MySystemsType> { }

// Здесь будет созданны структуры для систем
MySystems.Create();

// Добавление системы НЕ реализующей IUpdateSystem, то есть Init и\или Destroy системы
MySystems.AddCallOnce(new SomeInitSystem());
MySystems.AddCallOnce(new SomeDestroySystem>());
MySystems.AddCallOnce(new SomeInitDestroySystem>());

// Добавление системы реализующей IUpdateSystem, с наличием любых имплементаций таких как Init или Destroy
MySystems.AddUpdate(new SomeComboSystem());

// Важно! Системы запускаются в порядке перeданным вторым аргументом (по умолчанию order 0)
MySystems.AddUpdate(new SomeComboSystem(), order: 3);

// это значит что сначала будут запущены все Init системы в том порядке в котором добавлены
// затем в игровом цикле будут выполняться по порядку все Update системы
// затем по порядку вызовутся все системы типа Destroy при уничтожении мира

// Важно! Системы могут быть структурами или классами
// (использование структур может существенно увеличить производительность для небольших систем)

// Есть возможность подключать системы батчами что может существенно увеличить производительность
// Добавление батча систем, каждая система может реализовывать любые типы систем но обязана иметь реализацию IUpdateSystem
MySystems.AddUpdate(
    new SomeUpdateSystem1(),
    new SomeComboSystem1(),
    new SomeComboSystem2(),
    new SomeComboSystem3(),
    new SomeComboSystem4(),
    new SomeComboSystem5(),
    new SomeComboSystem()
);

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
- Представлен в виде статического класса `Ecs<IWorldType>.Context<T>`

<details><summary><u><b>Использование 👇</b></u></summary>

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

<details><summary><u><b>Использование 👇</b></u></summary>

Рассмотрим базовые возможности поиска сущностей в мире:
```c#
// Существует множество доступных вариантов запросов
// World.QueryEntities.For()\With() возвращает итератор сущностей подходящих под условие
// Для применение условий фильтрации компонентов доступны следующие типы:

// All - фильтрует сущности на наличие всех указанных компонентов (перегрузка от 1 до 8)
AllTypes<Types<Position, Direction, Velocity>> _all = default;
// или так
All<Position, Direction, Velocity> _all2 = default;

// AllAndNone - фильтрует сущности на наличие всех указанных компонентов первой группы и отсутсвие всех во второй (перегрузка от 1 до 8)
AllAndNoneTypes<Types<Position, Direction, Velocity>, Types<Name>> _allAndNone = default;

// None - фильтрует сущности на отсутсвие всех указанных компонентов (может использоваться только в составе других методов) (перегрузка от 1 до 8)
NoneTypes<Types<Name>> _none = default;
// или так
None<Name> _none2 = default;

// Any - фильтрует сущности на наличие любого из указанных компонентов (может использоваться только в составе других методов) (перегрузка от 1 до 8)
AnyTypes<Types<Position, Direction, Velocity>> _any = default;
// или так
Any<Position, Direction, Velocity> _any2 = default;

// Аналоги для тегов
// TagAll - фильтрует сущности на наличие всех указанных тегов (перегрузка от 1 до 8)
TagAllTypes<Tag<Unit, Player>> _all = default;
// или так
TagAll<Unit, Player> _all2 = default;

// AllAndNone - фильтрует сущности на наличие всех указанных тегов первой группы и отсутсвие всех во второй (перегрузка от 1 до 8)
TagAllAndNoneTypes<Tag<Unit>, Tag<Player>> _allAndNone = default;

// None - фильтрует сущности на отсутсвие всех указанных тегов (может использоваться только в составе других методов) (перегрузка от 1 до 8)
TagNoneTypes<Tag<Unit>> _none = default;
// или так
TagNone<Unit> _none2 = default;

// Any - фильтрует сущности на наличие любого из указанных тегов (может использоваться только в составе других методов) (перегрузка от 1 до 8)
TagAnyTypes<Tag<Unit, Player>> _any = default;
// или так
TagAny<Unit, Player> _any2 = default;

// Аналоги для масок
// MaskAll - фильтрует сущности на наличие всех указанных масок (может использоваться только в составе других методов) (перегрузка от 1 до 8)
MaskAllTypes<Mask<Flammable, Frozen, Visible>> _all = default;
// или так
MaskAll<Flammable, Frozen, Visible> _all2 = default;

// AllAndNone - фильтрует сущности на наличие всех указанных масок первой группы и отсутсвие всех во второй (перегрузка от 1 до 8)
MaskAllAndNoneTypes<Mask<Flammable, Frozen>, Mask<Visible>> _allAndNone = default;

// None - фильтрует сущности на отсутсвие всех указанных масок (может использоваться только в составе других методов) (перегрузка от 1 до 8)
MaskNoneTypes<Mask<Frozen>> _none = default;
// или так
MaskNone<Frozen> _none2 = default;

// Any - фильтрует сущности на наличие любой из указанных масок (может использоваться только в составе других методов) (перегрузка от 1 до 8)
MaskAnyTypes<Mask<Flammable, Frozen, Visible>> _any = default;
// или так
MaskAny<Flammable, Frozen, Visible> _any2 = default;

// Все типы выше не требуют явной инициализации, не требуют кеширования, каждый из них занимает не больше 1-2 байт и может использоваться "на лету"


// Различные наборы методов фильтрации могут быть применины к методу World.QueryEntities.For() например:
// Вариант с 1 методом через дженерик
foreach (var entity in MyWorld.QueryEntities.For<All<Position, Direction, Velocity>>()) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}

// Вариант с 1 методом через значение
var all = default(All<Position, Direction, Velocity>);
foreach (var entity in MyWorld.QueryEntities.For(all)) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}

// Вариант с 3 методами  через дженерик
foreach (var entity in MyWorld.QueryEntities.For<
             All<Position, Velocity, Name>,
             AllAndNoneTypes<Types<Position, Direction, Velocity>, Types<Name>>,
             None<Name>>()) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}

// Вариант с 3 методами  через значение
All<Position, Direction, Velocity> all2 = default;
AllAndNoneTypes<Types<Position, Direction, Velocity>, Types<Name>> allAndNone2 = default;
None<Name> none2 = default;
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

// Method 1 via generic
foreach (var entity in MyWorld.QueryEntities.With<With<
             All<Position, Velocity, Name>,
             AllAndNoneTypes<Types<Position, Direction, Velocity>, Types<Name>>,
             None<Name>,
             Any<Position, Direction, Velocity>
         >>()) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}

// Способ 2 через значения
With<
    All<Position, Velocity, Name>,
    AllAndNoneTypes<Types<Position, Direction, Velocity>, Types<Name>>,
    None<Name>,
    Any<Position, Direction, Velocity>
> with = default;
foreach (var entity in MyWorld.QueryEntities.With(with)) {
    entity.RefMut<Position>().Val *= entity.Ref<Velocity>().Val;
}

// Способ 3 через значения альтернативный
var with2 = With.Create(
    default(All<Position, Velocity, Name>),
    default(AllAndNoneTypes<Types<Position, Direction, Velocity>, Types<Name>>),
    default(None<Name>),
    default(Any<Position, Direction, Velocity>)
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

Look at additional ways to search for entities in the world:
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
    None<Direction>,
    Any<Position, Direction, Velocity>
> with = default;

MyWorld.QueryComponents.With(with).For(static (Ecs.Entity entity, ref Position position, ref Velocity velocity, ref Name name) => {
    position.Val *= velocity.Val;
});

// или так
MyWorld.QueryComponents.With<WithAdds<
    None<Direction>,
    Any<Position, Direction, Velocity>
>>().For(static (Ecs.Entity entity, ref Position position, ref Velocity velocity, ref Name name) => {
    position.Val *= velocity.Val;
});
```

Look at the special possibilities for finding entities in the world:
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
    None<Direction>,
    Any<Position, Direction, Velocity>
>>().For<Position, Velocity, Name, StructFunction>();

// Вариант 2 с With через значение
WithAdds<
    None<Direction>,
    Any<Position, Direction, Velocity>
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
// После вызова Ecs.Create(EcsConfig.Default());
// Можно явно зарегистрировать типы компонентов и получить структуру содержащую идентифкатор типа
ComponentDynId positionId = MyWorld.RegisterComponentType<Position>();
TagDynId unitTagId = MyWorld.RegisterTagType<Unit>();
MaskDynId frozenMaskId = MyWorld.RegisterMaskType<Frozen>();

// Альтернативно можно после инициализации мира в любой момент получить данные идентификаторы след образом:
ComponentDynId positionId = Ecs.Components.DynamicId<Position>();
TagDynId unitTagId = Ecs.Tags.DynamicId<Unit>();
MaskDynId frozenMaskId = Ecs.Masks.DynamicId<Frozen>();

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

```csharp
MyEcs.Create(EcsConfig.Default());
//...
MyEcs.World.RegisterComponentType<Position>(
                autoInit: static (ref Position position) => position.Val = Vector3.One, // заменяет поведение при создании компонента через метод Add
                autoReset: static (ref Position position) => position.Val = Vector3.One, // заменяет поведение при удалении компонента через метод Delete
                autoCopy: static (ref Position src, ref Position dst) => dst.Val = src.Val, // заменяет поведение при копировании компонента
            );
//...
MyEcs.Initialize();
```

> **Важно!** Стоит учитывать что создание сущности с установкой значения или добавления компонента через метод Put  
> полностью заменяют данные в компоненте, в обход установленных авто обработчиков

### События
Событие - cлужит для обмена информацией между системами или пользовательскими сервисами
- Представлено в виде пользовательской структуры с данными

Пример:
```c#
public struct WeatherChanged : IEvent { 
    public WeatherType WeatherType;
}
```

**ВАЖНО** ❗️  
Требуется регистрация в мире между созданием и инициализацией

Пример:
```c#
MyEcs.Create(EcsConfig.Default());
//...
MyEcs.Events.RegisterEventType<WeatherChanged>();
//...
MyEcs.Initialize();
```

<details><summary><u><b>Использование 👇</b></u></summary>

- Создание и базовые операции:
```c#
// Система событий будет создана при вызове MyEcs.Create и уничтожена при MyEcs.Destroy
MyEcs.Create(EcsConfig.Default());
MyEcs.Initialize();
//...

// Прежде чем отправлять событие следует зарегестрировать слушателя данного события, иначе событие не будет отправлено
// Слушатель может быть зарегестрирован после выозова Ecs.Create (например в Init методе системы)
var weatherChangedEventReceiver = MyEcs.Events.RegisterEventReceiver<WeatherChanged>();

// Удаление слушателя событий
MyEcs.Events.DeleteEventReceiver(ref weatherChangedEventReceiver);

// Важно! Жизненый цикл события: событие будет удалено в двух случаях:
// 1) когда оно будет прочитано всеми зарегестрированными слушателями
// 2) когда оно будет подавленно при прочтении (при вызове Suppress или SuppressAll метода (информация ниже) )
// Таким образом важно чтобы все зарегестрированные слушатели читали события или событие подавлялось каким либо слушателем, чтобы не было их накопления

// Отправка события
MyEcs.Events.Send(new WeatherChanged { WeatherType = WeatherType.Sunny });

// Отправка дефолтного значения события
MyEcs.Events.Send<WeatherChanged>();

// Получение динамического идентификатора типа события (смотри "Идентификаторы компонентов")
var weatherChangedDynId = MyEcs.Events.DynamicId<WeatherChanged>();
// Отправка дефолтного значения события (Подходит для маркерных событий без данных)
MyEcs.Events.SendDefault(weatherChangedDynId);

// Получение событий
foreach (var weatherEvent in weatherChangedEventReceiver) {
    Console.WriteLine("Weather is " + weatherEvent.Value.WeatherType);
}

foreach (var weatherEvent in weatherChangedEventReceiver) {
    // Подвление события - событие будет удалено и другие слушатели больше не смогут его прочитать
    weatherEvent.Suppress();
}

// Подавление всех событий для данного слушателя
weatherChangedEventReceiver.SuppressAll();

// Пометка о прочтении всех событий для данного слушателя
weatherChangedEventReceiver.MarkAsReadAll();

```
</details>

### Отношения
**WIP**

### Директивы компилятора
> `FFS_ECS_ENABLE_DEBUG`
> Включает режим отладки, по умолчанию включено в `DEBUG`, рекомендуется всегда работать в режиме отладки

> `FFS_ECS_ENABLE_DEBUG_EVENTS`
> Включает функциональность технических событий, по умолчанию включено в `DEBUG`

> `FFS_ECS_DISABLE_TAGS`
> Полностью исключает всю функциональность тегов из компиляции

> `FFS_ECS_DISABLE_MASKS`
> Полностью исключает всю функциональность масок из компиляции

> `FFS_ECS_LIFECYCLE_ENTITY`
> Меняет логику управления жизненым циклом сущности на автоматический, внося следующие изменения:
> - Сущность нельзя создать без компонента - метод MyEcs.Entity.New() недоступен, исключаются пустые сущности
> - При удалении последнего компонента типа `IComponent` сущность автоматически удаляется
>   - Стандартный компонент не учитываются
>   - Теги не учитываются
>   - Маски не учитываются


# Производительность
Актуальные бенчмарки : [BENCHMARKS](./Benchmark.md)

При использовании il2Cpp в Unity стоит отметить что прямые вызовы для получения компонентов чуть чуть быстрее:  
Например:
```csharp
// производительность в il2Cpp (в Mono нет разницы) может быть лучше во втором варианте на 10-40%
// это же касается тегов и масок и всех остальных методов HasAllOf<>, Delete<> и тд
ref var position = ref entity.RefMut<Position>(); // сахарный метод через сущность
ref var position = ref Ecs.Components<Position>.Value.RefMut(entity); // прямой вызов
```
```csharp
// так же можно использовать методы расширения которые практически приближены по производительности к прямому вызову
// Для их создания можно воспользоваться шаблоном live template для rider (читать далее) или кодогенерацией (WIP)
public static class PositionExtension {
    [MethodImpl(AggressiveInlining)]
    public static ref Position MutPosition(this Ecs.Entity entity) {
        return ref Ecs.Components<Position>.Value.RefMut(entity);
    }
}
ref var position = ref entity.RefMutPosition();
```
Component live template
```csharp
public static class $COMPONENT$Extension {
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static ref $COMPONENT$ Mut$COMPONENT$(this $ECS$.Entity entity) {
        return ref $ECS$.Components<$COMPONENT$>.Value.RefMut(entity);
    }
    
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static ref readonly $COMPONENT$ $COMPONENT$(this $ECS$.Entity entity) {
        return ref $ECS$.Components<$COMPONENT$>.Value.Ref(entity);
    }
    
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static ref $COMPONENT$ Add$COMPONENT$(this $ECS$.Entity entity) {
        return ref $ECS$.Components<$COMPONENT$>.Value.Add(entity);
    }
    
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void Add$COMPONENT$(this $ECS$.Entity entity, $COMPONENT$ value) {
        $ECS$.Components<$COMPONENT$>.Value.Add(entity) = value;
    }
    
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static ref $COMPONENT$ TryAdd$COMPONENT$(this $ECS$.Entity entity) {
        return ref $ECS$.Components<$COMPONENT$>.Value.TryAdd(entity);
    }
    
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void TryAdd$COMPONENT$(this $ECS$.Entity entity, $COMPONENT$ value) {
        $ECS$.Components<$COMPONENT$>.Value.TryAdd(entity) = value;
    }
    
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void Put$COMPONENT$(this $ECS$.Entity entity, $COMPONENT$ value) {
        $ECS$.Components<$COMPONENT$>.Value.Put(entity, value);
    }
    
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool Has$COMPONENT$(this $ECS$.Entity entity) {
        return $ECS$.Components<$COMPONENT$>.Value.Has(entity);
    }
    
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool Delete$COMPONENT$(this $ECS$.Entity entity) {
        return $ECS$.Components<$COMPONENT$>.Value.Del(entity);
    }
}
```

Standard component live template
```csharp
public static class $COMPONENT$Extension {
    
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static ref readonly $COMPONENT$ $COMPONENT$(this $ECS$.Entity entity) {
        return ref $ECS$.StandardComponents<$COMPONENT$>.Value.Ref(entity);
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static ref $COMPONENT$ Mut$COMPONENT$(this $ECS$.Entity entity) {
        return ref $ECS$.StandardComponents<$COMPONENT$>.Value.RefMut(entity);
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void Set$COMPONENT$(this $ECS$.Entity entity, $COMPONENT$ value) {
        $ECS$.StandardComponents<$COMPONENT$>.Value.RefMut(entity) = value;
    }
}
```

Tag live template
```csharp
public static class $TAG$Extension {
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void Set$TAG$(this $Ecs$.Entity entity) {
        $Ecs$.Tags<$TAG$>.Value.Set(entity);
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool Has$TAG$(this $Ecs$.Entity entity) {
        return $Ecs$.Tags<$TAG$>.Value.Has(entity);
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool Delete$TAG$(this $Ecs$.Entity entity) {
        return $Ecs$.Tags<$TAG$>.Value.Del(entity);
    }
}
```

Mask live template
```csharp
public static class $MASK$Extension {
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void Set$MASK$(this $Ecs$.Entity entity) {
        $Ecs$.Masks<$MASK$>.Value.Set(entity);
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static bool Has$MASK$(this $Ecs$.Entity entity) {
        return $Ecs$.Masks<$MASK$>.Value.Has(entity);
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void Delete$MASK$(this $Ecs$.Entity entity) {
        $Ecs$.Masks<$MASK$>.Value.Del(entity);
    }
}
```

# Интеграция в движки
### Unity
Пример:
```csharp
using System;
using UnityEngine;
using FFS.Libraries.StaticEcs;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public struct MyWorldType : IWorldType { }
public struct MySystemsType : ISystemsType { }

public abstract class MyEcs : Ecs<MyWorldType> { }
public abstract class MyWorld : MyEcs.World { }
public abstract class MySystems : MyEcs.Systems<MySystemsType> { }

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
        MyEcs.Create(EcsConfig.Default());
        
        MyWorld.RegisterComponentType<Position>();
        MyWorld.RegisterComponentType<Direction>();
        MyWorld.RegisterComponentType<Velocity>();
        
        MyEcs.Initialize();
        
        MyEcs.Context<SceneData>.Set(sceneData);
        
        MySystems.Create();
        
        MySystems.AddCallOnce(new CreateRandomEntities());
        MySystems.AddUpdate(new UpdatePositions());
        
        MySystems.Initialize();
    }

    void Update() {
        MySystems.Update();
    }

    private void OnDestroy() {
        MySystems.Destroy();
        MyEcs.Destroy();
    }
}
```

# Вопрос-ответ
**WIP**

# Лицензия
[MIT license](./LICENSE.md)
