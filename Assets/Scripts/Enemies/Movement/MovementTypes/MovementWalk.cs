using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWalk : MovementAbstract
{
    private float _stepDistance = 1.0f;
    private float _baseStepDelay = 1.0f;
    private float _baseStepTime = 1.0f;
    private float _stepTime;
    private float _stepsDelay;

    public override void UpdateMultiplier()
    {
        float multiplier = MultiplierManager.Instance.MultiplierValue;

        _stepTime = _baseStepTime / BaseMoveSpeed / multiplier;
        _stepsDelay = _baseStepDelay / multiplier;
        _viewAnimator.speed = multiplier * 0.7f;
    }

    public override void StartMovement()
    {
        _isMoving = true;
        UpdateMultiplier();
        StartCoroutine(StepLoop());
    }

    public override void StopMovement()
    {
        _isMoving = false;
    }

    private IEnumerator StepLoop()
    {
        while (true)
        {
            if (_isMoving)
            {
                yield return StartCoroutine(
                    MakeStep(transform.position,
                    transform.position + Vector3.right * _stepDistance)
                );

                yield return new WaitForSeconds(_stepsDelay);
            }
            else
            {
                yield return null;
            }
        }
    }

    private IEnumerator MakeStep(Vector3 startPosition, Vector3 endPosition)
    {
        _viewAnimator.Play("EnemyWalk", 0, 0f);

        float elapsedTime = 0;
        while (elapsedTime < _stepTime)
        {
            if (_isMoving)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / _stepTime);
                elapsedTime += Time.deltaTime;
            }
            yield return null;
        }
        transform.position = endPosition;
    }
}
