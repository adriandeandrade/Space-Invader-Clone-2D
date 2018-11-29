using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float amountToSpawn;
    [SerializeField] private Vector3 initalSpawnPosition;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private GameObject enemyHolder;

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
                GameObject e = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                e.transform.parent = enemyHolder.transform;
                GameManager.instance.enemiesLeft += 1;
                spawnPosition = new Vector3(spawnPosition.x + 1, spawnPosition.y, 0f);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.05f);
            spawnPosition.x = -4.506f;
            spawnPosition.y -= 1;
            rowAmount -= 1;
        }

        enemyMovement.doMovement = true;
        StartCoroutine(enemyMovement.Movement());
    }
}
