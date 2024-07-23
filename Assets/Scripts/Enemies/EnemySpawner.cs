using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float maxOffsetY;
    private EnemiesSpawnGetter _enemiesSpawnGetter;

    void Awake() {
        _enemiesSpawnGetter = gameObject.GetComponent<EnemiesSpawnGetter>();
    }

    void Start()
    {
        StartEnemiesSpawn();
    }

    void StartEnemiesSpawn() {
        StartCoroutine(SpawnEnemyWithDelay(_spawnDelay));
    }

    private IEnumerator SpawnEnemyWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnEnemy();
        StartCoroutine(SpawnEnemyWithDelay(_spawnDelay));
    }

    void SpawnEnemy() {
        float spawnOffsetY = Random.Range(-maxOffsetY, maxOffsetY);
        Vector3 spawnPosition = new Vector3(0f, spawnOffsetY, 0f);

        GameObject enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity, gameObject.transform);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();
        enemyComponent.Setup(_enemiesSpawnGetter.GetRandom());
    }
}
