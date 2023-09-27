using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> spawnPoints;
    [SerializeField] private float timeBetweenSpawns = 3;
    [SerializeField] private PawnBase enemyPrefab;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            SpawnPoint spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            if (spawnPoint.IsFreeToSpawn())
            {
                Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                timeBetweenSpawns *= .95f;
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
            else
            {
                yield return null;
            }
        }
    }
}
