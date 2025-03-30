---
title: Auto handlers
parent: Additional features
nav_order: 2
---

### Auto handlers
By default, when adding or deleting a component, the data is filled with the default value, and when copying, the component is completely copied  
To set your own logic of default initialization and resetting of the component you can use handlers

```csharp
MyEcs.Create(EcsConfig.Default());
//...
MyEcs.World.RegisterComponentType<Position>(
                autoInit: static (ref Position position) => position.Val = Vector3.One, // replaces the behavior when creating a component via the Add method
                autoReset: static (ref Position position) => position.Val = Vector3.One, // replaces the behavior when deleting a component via the Delete method
                autoCopy: static (ref Position src, ref Position dst) => dst.Val = src.Val, // replaces the behavior when copying a component
            );
//...
MyEcs.Initialize();
```
> **Important!** Keep in mind that creating an entity with a value or adding a component via the Put method  
> completely replace the data in the component, bypassing the auto handlers installed