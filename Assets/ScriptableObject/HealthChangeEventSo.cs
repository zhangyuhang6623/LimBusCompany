using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/HealthChangeEventSo")]

public class HealthChangeEventSo : ScriptableObject
{
    public UnityAction<Character> OnHealthChangeEvent;
    public void OnEventRaise(Character character)
    {
        OnHealthChangeEvent?.Invoke(character);
    }
}
