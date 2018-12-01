using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;

    private void Update()
    {
        if(health <= 0)
        {
            Die();
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= (int)amount;
        UIManager.instance.HideHealth(health);
    }

    private void Die()
    {
        GameManager.instance.EndGame();
        Destroy(gameObject);
    }
}
