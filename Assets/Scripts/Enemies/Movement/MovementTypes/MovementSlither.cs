using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSlither : MovementAbstract
{
    private float _stepDistance = 1.0f;
    private float _backStepDistance = 0.1f;
    private float _basePreStepDelay = 0.3f;
    private float _baseStepDelay = 1.0f;
    private float _baseStepTime = 0.7f;
    private float _stepTime;
    private float _stepsDelay;
    private float _preStepDelay;

    public override void UpdateMultiplier()
    {
        float multiplier = MultiplierManager.Instance.MultiplierValue;

        _stepTime = _baseStepTime / (BaseMoveSpeed * multiplier);
        _stepsDelay = _baseStepDelay / multiplier;
        _preStepDelay = _basePreStepDelay / multiplier;
        _viewAnimator.speed = multiplier * 2.0f;
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
        _viewAnimator.Play("EnemySlithering", 0, 0f);

        float elapsedTime = 0;
        Vector3 moveBackPosition = startPosition - new Vector3(_backStepDistance, 0f, 0f);
        while (elapsedTime < _preStepDelay)
        {
            transform.position = Vector3.Lerp(startPosition, moveBackPosition, elapsedTime / _preStepDelay);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0;
        while (elapsedTime < _stepTime)
        {
            if (_isMoving)
            {
                transform.position = Vector3.Lerp(moveBackPosition, endPosition, elapsedTime / _stepTime);
                elapsedTime += Time.deltaTime;
            }
            yield return null;
        }
        transform.position = endPosition;
    }
}
