using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject hitEffect;

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
            Destroy(gameObject);
            GameObject effect = Instantiate(hitEffect, other.transform.position, Quaternion.identity);
            Destroy(effect, 3f);
            IDamageable damageable = other.GetComponent<IDamageable>();

            if(damageable != null)
            {
                FindObjectOfType<AudioManager>().Play("Hit");
                damageable.TakeDamage(1);
            }
        }

        if (other.CompareTag("TransportShip"))
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(hitEffect, other.transform.position, Quaternion.identity);
            Destroy(effect, 3f);
            IDamageable damageable = other.GetComponent<IDamageable>();

            if (damageable != null)
            {
                FindObjectOfType<AudioManager>().Play("Hit");
                damageable.TakeDamage(1);
            }
        }
    }
}
