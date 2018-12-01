using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootManager : MonoBehaviour
{
    [SerializeField] private float enemyPickIntervalCooldown;
    private float nextPickTime;

    [HideInInspector] public bool startPicking = false;
    [HideInInspector] public bool doShooting = false;

    private void Start()
    {
        nextPickTime = enemyPickIntervalCooldown + (Random.value * 1.5f);
    }

    private void Update()
    {
        if(Time.time > nextPickTime)
        {
            FindEnemies();
            PickRandomEnemyAndShoot();
            nextPickTime = Time.time + enemyPickIntervalCooldown;
        }
    }

    public void FindEnemies()
    {
        GameManager.instance.enemies = new List<GameObject>();
        Enemy[] tempEnemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in tempEnemies)
        {
            GameObject e = enemy.gameObject;
            GameManager.instance.enemies.Add(e);
        }
    }

    public GameObject PickRandomEnemyAndShoot()
    {
        if(GameManager.instance.enemies != null && doShooting)
        {
            int randomEnemy = Random.Range(0, GameManager.instance.enemies.Count);
            GameManager.instance.enemies[randomEnemy].GetComponent<EnemyShooting>().Shoot();
        }


        return null;
    }
}
