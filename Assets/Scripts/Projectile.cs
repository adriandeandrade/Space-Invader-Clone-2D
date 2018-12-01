using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    [SerializeField] private GunType projectileType;
    [SerializeField] private GameObject hitEffect;

    private void Update()
    {
        transform.Translate(transform.up * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            IDamageable damageableObject = other.GetComponent<IDamageable>(); 
            if (damageableObject != null)
            {
                switch (GameManager.instance.weaponSystem.currentFireMode)
                {
                    case WeaponSystem.FireMode.BULLET:
                        BulletBehavior(other);
                        Destroy(gameObject);
                        break;

                    case WeaponSystem.FireMode.EXPLOSIVE:
                        ExplosiveBulletBehavior(other);
                        Destroy(gameObject);
                        break;
                }
            }
        }
    }

    private void BulletBehavior(Collider2D other)
    {
        GameObject effect = Instantiate(hitEffect, other.transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        other.GetComponent<IDamageable>().TakeDamage(projectileType.damage);
        FindObjectOfType<AudioManager>().Play("Hit");
    }

    private void ExplosiveBulletBehavior(Collider2D other)
    {
        Collider2D[] nearby = Physics2D.OverlapCircleAll(other.transform.position, projectileType.damageRange);

        if (nearby.Length > 0)
        {
            foreach (Collider2D enemy in nearby)
            {
                Enemy e = enemy.GetComponent<Enemy>();

                if(e != null)
                {
                    float proximity = (other.transform.position - e.transform.position).magnitude;
                    float damageAmount = 1 - (proximity / projectileType.damageRange);

                    GameObject effect = Instantiate(hitEffect, other.transform.position, Quaternion.identity);
                    Destroy(effect, 3f);
                    enemy.GetComponent<IDamageable>().TakeDamage(projectileType.damage * damageAmount + 0.5f);
                    FindObjectOfType<AudioManager>().Play("Hit");
                }
            }
        }
    }
}
