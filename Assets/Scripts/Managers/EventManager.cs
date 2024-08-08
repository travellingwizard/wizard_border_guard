using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public event Action<SpellShotData> CheckSpellHit;
    public event Action SpellCasted;

    void Awake() {
        Instance = this;
    }
    
    public void OnCastSpell(SpellShotData spellShotData) {
        CheckSpellHit?.Invoke(spellShotData);
        SpellCasted?.Invoke();
    }
}
