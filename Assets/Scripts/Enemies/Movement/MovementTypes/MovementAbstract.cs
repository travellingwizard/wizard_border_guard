using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MovementAbstract : MonoBehaviour, IEnemyMovement
{
    public float BaseMoveSpeed { get; set; } = 1.0f;
    protected Animator _viewAnimator;
    protected bool _isMoving = false;

    void Awake()
    {
        Transform childTransform = transform.Find("View");
        _viewAnimator = childTransform.gameObject.GetComponentInChildren<Animator>();
    }

    void Start() {
        MultiplierManager.Instance.MultiplierChange += UpdateMultiplier;
    }

    public abstract void UpdateMultiplier();
    public abstract void StartMovement();
    public abstract void StopMovement();
}
