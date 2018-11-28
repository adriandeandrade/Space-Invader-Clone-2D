using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    public int health;

    private void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int amount)
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
        Destroy(gameObject);
    }
}
