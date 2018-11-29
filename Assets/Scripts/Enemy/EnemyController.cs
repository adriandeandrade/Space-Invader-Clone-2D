using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    public float health;

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float amount)
    {
        if (health > 0)
        {
            health -= amount;
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.instance.enemiesLeft -= 1;
        Destroy(gameObject);
    }
}
