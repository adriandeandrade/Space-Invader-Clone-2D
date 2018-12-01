using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;

    [SerializeField] private float shootIntervalCooldown;
    private float nextShotTime;

    [SerializeField] private GameObject enemyProjectilePrefab;

    private void Start()
    {
        shootPoint = transform.GetChild(0);
        nextShotTime = shootIntervalCooldown + (Random.value * 1.5f);
    }

    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            GameObject eBullet = Instantiate(enemyProjectilePrefab, shootPoint.position, Quaternion.identity);
            Destroy(eBullet, 5f);
        }
    }
}
