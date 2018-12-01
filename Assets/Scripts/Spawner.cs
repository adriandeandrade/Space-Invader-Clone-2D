using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner Options")]
    [SerializeField] private Vector3 initalSpawnPosition;
    [SerializeField] private float nextXAmount;
    [SerializeField] private float nextYAmount;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private float amountToSpawnPerRow;
    [SerializeField] private int rowAmount = 3;

    [Header("Other Spawner Options")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyHolder;

    [SerializeField] private EnemyShootManager enemyShootManager;

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
            for (int i = 0; i < amountToSpawnPerRow; i++)
            {
                GameObject e = Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
                e.transform.parent = enemyHolder.transform;
                spawnPosition = new Vector3(spawnPosition.x + nextXAmount, spawnPosition.y, 0f);
                GameManager.instance.enemiesLeft += 1;
                yield return new WaitForSeconds(spawnSpeed);
            }
            
            spawnPosition.x = initalSpawnPosition.x;
            spawnPosition.y -= nextYAmount;
            rowAmount -= 1;
        }

        enemyMovement.doMovement = true;
        enemyShootManager.startPicking = true;
        enemyShootManager.doShooting = true;
        StartCoroutine(enemyMovement.Movement());
    }
}
