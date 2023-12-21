using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public  static class ExtensionMethod{
    public static TComponent CopyComponent<TComponent>(this GameObject destination,TComponent originalComponent) where TComponent : Component
    {
        Type componentType = originalComponent.GetType();
        Component copy = destination.AddComponent(componentType);

        FieldInfo[] fields = componentType.GetFields();
        
        foreach (FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(originalComponent));
        }

        return copy as TComponent;
    }
}

