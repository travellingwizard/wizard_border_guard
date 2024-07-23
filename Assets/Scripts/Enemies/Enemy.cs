using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private HPBarEnemy _hpBarEnemy;
    private float _speed = 0;
    private int _hp = 0;
    private int _sortingOrderAccuracy = 1000;

    public void Setup(EnemyScriptableObj enemyObj)
    {
        _speed = enemyObj.moveSpeed;
        _hp = enemyObj.GetHp();
        _view.GetComponent<SpriteRenderer>().sprite = enemyObj.view;
        _hpBarEnemy.SetHP(_hp);


        SortingGroup sortingGroup = gameObject.GetComponent<SortingGroup>();
        sortingGroup.sortingOrder = -Mathf.RoundToInt(gameObject.transform.position.y * 100);

    }
}
