using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsSpawnGetter : MonoBehaviour
{
    [SerializeField] private SpellScriptableObj[] _spells;
    [SerializeField] private int[] _chances;
    
    public SpellScriptableObj GetRandomSpell() {
        int randomChance = Random.Range(1, 101);

        for (int i = 0; i < _chances.Length; i++)
        {
            if (randomChance <= _chances[i])
            {
                return _spells[i];
            }
        }

        return _spells[0];
    }
}
