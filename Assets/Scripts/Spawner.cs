using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float amountToSpawn;
    [SerializeField] private Vector3 initalSpawnPosition;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private GameObject enemyHolder;

    [SerializeField] private EnemyShootManager enemyShootManager;

    private int rowAmount = 3;

    private Vector3 spawnPosition;

    private EnemyMovement enemyMovement;

    private void Start()
    {
        spawnPosition = initalSpawnPosition;
        StartCoroutine(SpawnEnemies());
        enemyMovement = FindObjectOfType<EnemyMovement>();
    }

    IEnumerator SpawnEnemies()
    {
        while(rowAmount > 0)
        {
            for (int i = 0; i < amountToSpawn; i++)
            {
                GameObject e = Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
                e.transform.parent = enemyHolder.transform;
                spawnPosition = new Vector3(spawnPosition.x + 1.54f, spawnPosition.y, 0f);
                GameManager.instance.enemiesLeft += 1;
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.05f);
            spawnPosition.x = -3.85f;
            spawnPosition.y -= 1.16f;
            rowAmount -= 1;
        }

        enemyMovement.doMovement = true;
        enemyShootManager.startPicking = true;
        StartCoroutine(enemyMovement.Movement());
    }
}
