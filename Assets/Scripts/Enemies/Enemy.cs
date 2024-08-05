using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private HPBarEnemy _hpBarEnemy;
    private int _hp = 0;
    private IEnemyMovement _movementScript;

    public void Setup(EnemyScriptableObj enemyObj)
    {
        _hp = enemyObj.GetHp();
        _view.GetComponent<SpriteRenderer>().sprite = enemyObj.view;
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
}
