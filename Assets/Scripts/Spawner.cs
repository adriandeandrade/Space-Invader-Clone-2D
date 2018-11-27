using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float amountToSpawn;
    [SerializeField] private Vector3 initalSpawnPosition;

    [SerializeField] private GameObject enemyPrefab;

    private Vector3 spawnPosition;

    private void Start()
    {
        spawnPosition = initalSpawnPosition;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            spawnPosition = new Vector3(spawnPosition.x + 1, spawnPosition.y, 0f);
            yield return new WaitForSeconds(0.2f);
        }
    }

}
