using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventChannel", menuName = "ScriptableObjects/RSE/EventChannel/EventChannel")]
public class RSE_EventChannel : ScriptableObject
{
    private Action onEventRaised;

    public void RegisterListener(Action listener)
    {
        onEventRaised += listener;
    }

    public void UnregisterListener(Action listener)
    {
        onEventRaised -= listener;
    }

    public void RaiseEvent()
    {
        onEventRaised?.Invoke();
    }
}
