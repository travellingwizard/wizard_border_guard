using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _baseSpawnDelay;
    [SerializeField] private float maxOffsetY;
    private float _spawnDelay;
    private EnemiesSpawnGetter _enemiesSpawnGetter;

    void Awake()
    {
        _enemiesSpawnGetter = gameObject.GetComponent<EnemiesSpawnGetter>();
    }

    void Start()
    {
        UpdateMultiplier();
        MultiplierManager.Instance.MultiplierChange += UpdateMultiplier;

        StartEnemiesSpawn();
    }

    public void UpdateMultiplier()
    {
        float multiplier = MultiplierManager.Instance.MultiplierValue;
        _spawnDelay = _baseSpawnDelay / multiplier;
    }

    void StartEnemiesSpawn()
    {
        SpawnEnemy();
        StartCoroutine(SpawnEnemyWithDelay());
    }

    private IEnumerator SpawnEnemyWithDelay()
    {
        yield return new WaitForSeconds(_spawnDelay);
        SpawnEnemy();
        StartCoroutine(SpawnEnemyWithDelay());
    }

    void SpawnEnemy()
    {
        float spawnOffsetY = Random.Range(-maxOffsetY, maxOffsetY);
        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            transform.position.y + spawnOffsetY,
            0f);

        GameObject enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity, gameObject.transform);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();
        enemyComponent.Setup(_enemiesSpawnGetter.GetRandom());
    }
}
