using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
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
        GameManager.instance.enemiesKilled++;
        print("Enemies Killed: " + GameManager.instance.enemiesKilled);

        if(GameManager.instance.enemiesLeft <= 0)
        {
            GameManager.instance.WinGame();
        }

        foreach (GameObject e in GameManager.instance.enemies)
        {
            if(e == this)
            {
                GameManager.instance.enemies.Remove(e);
                return;
            }
        }
        Destroy(gameObject);
    }
}
