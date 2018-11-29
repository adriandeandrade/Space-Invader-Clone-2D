using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private void Update()
    {
        transform.Translate(-transform.up * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
