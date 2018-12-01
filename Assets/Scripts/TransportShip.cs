using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportShip : MonoBehaviour, IDamageable
{
    [SerializeField] private float health;

    private void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    private void Die()
    {
        GameManager.instance.shipsLeft -= 1;
        Destroy(gameObject);
    }
}
