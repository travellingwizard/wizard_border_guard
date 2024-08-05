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
    public MovementType moveType = MovementType.Walk;

    public int GetHp()
    {
        return possibleHp[Random.Range(0, possibleHp.Length)];
    }
}
