using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy Scriptable Object")]
public class EnemyScriptableObj : ScriptableObject
{
    public Sprite view;
    public AudioClip sound;
    public int[] possibleHp;
    public float moveSpeed;
    public int moveType = 0;

    public int GetHp()
    {
        return possibleHp[Random.Range(0, possibleHp.Length)];
    }
}
