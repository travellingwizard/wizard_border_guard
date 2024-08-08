using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private HPBarEnemy _hpBarEnemy;
    private SpriteRenderer _viewSprite;
    private Animator _animator;
    private int _hp = 0;
    private IEnemyMovement _movementScript;

    public void Awake()
    {
        _viewSprite = _view.GetComponent<SpriteRenderer>();
        _animator = gameObject.GetComponent<Animator>();
    }

    public void Setup(EnemyScriptableObj enemyObj)
    {
        _hp = enemyObj.GetHp();
        _viewSprite.sprite = enemyObj.view;
        _hpBarEnemy.SetHP(_hp);

        SortingGroup sortingGroup = gameObject.GetComponent<SortingGroup>();
        sortingGroup.sortingOrder = -Mathf.RoundToInt(gameObject.transform.position.y * 100);

        SetupMovement(enemyObj.moveType, enemyObj.moveSpeed);
        _movementScript.StartMovement();
    }

    private void SetupMovement(MovementType moveType, float moveSpeed)
    {
        if (moveType == MovementType.Walk)
        {
            _movementScript = gameObject.AddComponent<MovementWalk>();
        }
        else if (moveType == MovementType.Fly)
        {
            _movementScript = gameObject.AddComponent<MovementFly>();
        }
        else if (moveType == MovementType.Run)
        {
            _movementScript = gameObject.AddComponent<MovementRun>();
        }
        else if (moveType == MovementType.Slither)
        {
            _movementScript = gameObject.AddComponent<MovementSlither>();
        }

        _movementScript.BaseMoveSpeed = moveSpeed;
    }

    public void GetHit(SpellShotData spellShotData)
    {
        StartCoroutine(_playRed());

        if (spellShotData.Instakill)
            _hp = 0;
        else
            _hp -= spellShotData.Damage;

        if (_hp <= 0)
        {
            StartCoroutine(_die(Math.Abs(_hp)));
            _hp = 0;
        }

        _hpBarEnemy.SetHP(Math.Max(0, _hp));
    }

    private IEnumerator _playRed()
    {
        _viewSprite.color = new Color(1f, 0f, 0f);
        yield return new WaitForSeconds(0.2f);
        _viewSprite.color = new Color(1f, 1f, 1f);
    }

    private IEnumerator _die(float overkill)
    {
        _movementScript.StopMovement();
        _animator.Play("EnemyContainerDie", 0, 0f);

        yield return new WaitForSeconds(0.7f);

        Debug.Log($"Killed with overkill: {overkill}.");
        Destroy(gameObject);
    }
}
