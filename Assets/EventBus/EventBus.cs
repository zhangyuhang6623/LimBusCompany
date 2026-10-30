using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public static class EventBus
{
    public static readonly Dictionary<Type, List<Delegate>> eventBus = new();
    /// <summary>
    /// 注册一个事件，监听TEvent
    /// </summary>
    public static void Subscribe<TEvent >(Action<TEvent> action)where TEvent:struct
    {
        Type type = typeof(TEvent);
        if(!eventBus.TryGetValue(type,out var list))
        {
           list=new List<Delegate>();
           eventBus.Add(type,list);
        }
        if (!list.Contains(action))
        {
            list.Add(action);
        }
    }
    /// <summary>
    /// 取消对莫一个事件的监听
    /// </summary>
    public static void Unsubscribe<TEvent>(Action<TEvent> action)
    {
        Type type = typeof(TEvent);
        if (eventBus.TryGetValue(type, out var list))
        {
            list.Remove(action);
        }
    }
    /// <summary>
    /// 广播TEvent，使得监听TEvent的函数执行逻辑
    /// </summary>
    public static void Publish<TEvent>(TEvent T)
    {
        Type type=typeof(TEvent);
        if(eventBus.TryGetValue(type,out var list))
        {
            List<Delegate> delegates = list;
            for (int i = delegates.Count-1; i >=0; i--) {
                try
                {
                    if (list[i] is Action<TEvent> action)
                    {
                        action?.Invoke(T);
                    }
                }
                catch { }

            }
        }
    }
    //清理所有监听TEvent的监听者
    public static void Clear<TEvent>()
    {
        Type type=typeof(TEvent);
        eventBus.Remove(type);
    }
}
