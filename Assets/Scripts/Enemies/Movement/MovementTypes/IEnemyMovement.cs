using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMovement
{
    public float BaseMoveSpeed { get; set; }
    public void StartMovement() { }
    public void StopMovement() { }
    public void UpdateMultiplier(float multiplier) { }
}
