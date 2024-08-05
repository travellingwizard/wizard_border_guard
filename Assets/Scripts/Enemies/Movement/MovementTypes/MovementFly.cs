using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFly : MovementAbstract
{
    private float _flySpeed = 1.0f;

    public override void UpdateMultiplier()
    {
        float multiplier = MultiplierManager.Instance.MultiplierValue;
        _flySpeed = BaseMoveSpeed * multiplier;
        _viewAnimator.speed = multiplier;
    }

    public override void StartMovement()
    {
        _isMoving = true;
        UpdateMultiplier();
        _viewAnimator.Play("EnemyFly", 0, 0f);
    }

    public override void StopMovement()
    {
        _isMoving = false;
    }

    void Update()
    {
        if (_isMoving)
        {
            float moveStep = Time.deltaTime * _flySpeed;
            transform.Translate(Vector3.right * moveStep);
        }
    }
}
