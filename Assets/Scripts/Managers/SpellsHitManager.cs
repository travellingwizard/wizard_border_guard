using System;
using UnityEngine;

public class SpellsHitManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemiesContainer;
    [SerializeField] private float _hitRadius;

    void Start()
    {
        EventManager.Instance.CheckSpellHit += CheckSpellHit;
    }

    private void CheckSpellHit(SpellShotData spellShotData)
    {
        Transform target = getTarget(spellShotData.Position);
        if (target == null) return;

        target.gameObject.GetComponent<Enemy>().GetHit(spellShotData);
    }

    private Transform getTarget(Vector3 position)
    {
        float minDistance = float.PositiveInfinity;
        Transform closestEnemy = null;

        foreach (Transform enemy in _enemiesContainer.transform)
        {
            float distance = Vector3.Distance(enemy.position, position);
            if (distance < _hitRadius)
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }
}
