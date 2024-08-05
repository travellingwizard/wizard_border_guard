using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public event Action SpellCasted;

    void Awake() {
        Instance = this;
    }
    
    public void OnCastSpell(Vector3 worldPosition) {
        Debug.Log($"Spell used in coordinates: {worldPosition}, INSTAKILL");
        SpellCasted?.Invoke();
    }

    public void OnCastSpell(Vector3 worldPosition, int damage) {
        Debug.Log($"Spell used in coordinates: {worldPosition} with damage {damage}");
        SpellCasted?.Invoke();
    }
}
