using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MultiplierManager : MonoBehaviour
{
    public static MultiplierManager Instance;
    public float MultiplierValue {get; private set;} = 1f;
    public event Action MultiplierChange;

    void Awake() {
        Instance = this;
    }

    void Start() {
        
    }

    void UpdateMultiplier() {
        MultiplierChange?.Invoke();
    }
}
