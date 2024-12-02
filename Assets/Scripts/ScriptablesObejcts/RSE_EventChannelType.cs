using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSE_EventChannelType<T> : ScriptableObject
{
    private Action<T> onEventRaised;

    public void RegisterListener(Action<T> listener)
    {
        onEventRaised += listener;
    }

    public void UnregisterListener(Action<T> listener)
    {
        onEventRaised -= listener;
    }

    public void RaiseEvent(T value)
    {
        onEventRaised?.Invoke(value);
    }
}
