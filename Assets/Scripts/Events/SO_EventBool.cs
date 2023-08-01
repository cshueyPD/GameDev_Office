using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_EventBool : ScriptableObject
{
    private List<EventListenerBool> listeners =
        new List<EventListenerBool>();

    public void Raise(bool value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(value);
    }

    public void RegisterListener(EventListenerBool listener) => listeners.Add(listener);

    public void UnregisterListener(EventListenerBool listener) => listeners.Remove(listener);
}