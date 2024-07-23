using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectsGetter<T> : MonoBehaviour where T : ScriptableObject
{
    [SerializeField] private T[] _scriptableObjects;
    [SerializeField] private int[] _chances;
    
    public T GetRandom() {
        int randomChance = Random.Range(1, 101);

        for (int i = 0; i < _chances.Length; i++)
        {
            if (randomChance <= _chances[i])
            {
                return _scriptableObjects[i];
            }
        }

        return _scriptableObjects[0];
    }
}
