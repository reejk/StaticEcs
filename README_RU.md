![Version](https://img.shields.io/badge/version-0.9.73-blue.svg?style=for-the-badge)

### ЯЗЫК
[RU](./README_RU.md)
[EN](./README.md)
___
### 🚀 **[Benchmarks](./docs/Benchmark.md)** 🚀
### ⚙️ **[Unity модуль](https://github.com/Felid-Force-Studios/StaticEcs-Unity)** ⚙️
### 📖️ **[Документация](https://felid-force-studios.github.io/StaticEcs/ru/)** 📖️
 
# Static ECS - C# Entity component system framework
- Легковесность
- Производительность
- Отсутсвие аллокаций
- Отсутствие зависимостей
- Без Unsafe в ядре
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
* [Концепция](#концепция)
* [Быстрый старт](#быстрый-старт)
* [Лицензия](#лицензия)


# Контакты
* [Telegram](https://t.me/felid_force_studios)

# Установка
* ### В виде исходников
  Со страцины релизов или как архив из нужной ветки. В ветке `master` стабильная проверенная версия
* ### Установка для Unity
  Как git модуль `https://github.com/Felid-Force-Studios/StaticEcs.git` в Unity PackageManager или добавления в `Packages/manifest.json`:

# Концепция
> - Основная идея данной реализации в статике, все данные о мире и компонентах находятся в статических классах, что дает вохможность избегать дорогостоящих виртуальных вызовов, иметь удобный API со множеством сахара
> - Даннный фреймворк нацелен на максмальную простоту использования, скорость и комфорт написания кода без жертв в производительности
> - Доступно создание мульти-миров, строгая типизация, обширные бесплатные абстракции
> - Основан на sparse-set архитектуре, ядро вдохновленно серией библиотек от Leopotam
> - Фреймворк создан для нужд частного проекта и выложен в open-source.

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

# Лицензия
[MIT license](./LICENSE.md)
