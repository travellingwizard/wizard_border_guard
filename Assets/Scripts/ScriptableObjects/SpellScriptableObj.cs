using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell Scriptable Object")]
public class SpellScriptableObj : ScriptableObject
{
    public Sprite view;
    public AudioClip sound;
    public int[] possibleDamage;
    public int[] possibleChances;
    public bool isInstakill;

    public int GetDamage()
    {
        int randomChance = Random.Range(1, 101);

        for (int i = 0; i < possibleChances.Length; i++)
        {
            if (randomChance <= possibleChances[i])
            {
                return possibleDamage[i];
            }
        }

        return possibleDamage[0];
    }
}
