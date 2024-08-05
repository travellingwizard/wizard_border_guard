using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRun : MovementAbstract
{
    private float _runSpeed = 1.0f;

    public override void UpdateMultiplier()
    {
        float multiplier = MultiplierManager.Instance.MultiplierValue;
        _runSpeed = BaseMoveSpeed * multiplier;
        _viewAnimator.speed = multiplier;
    }

    public override void StartMovement()
    {
        _isMoving = true;
        UpdateMultiplier();
        _viewAnimator.Play("EnemyRun", 0, 0f);
    }

    public override void StopMovement()
    {
        _isMoving = false;
    }

    void Update()
    {
        if (_isMoving)
        {
            float moveStep = Time.deltaTime * _runSpeed;
            transform.Translate(Vector3.right * moveStep);
        }
    }
}
