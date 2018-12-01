using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Options")]

    [SerializeField] private float xIncrementAmount;
    [SerializeField] private float enemyMoveSpeed;
    [SerializeField] private float yDropAmount;
    [SerializeField] private float minXBound;
    [SerializeField] private float maxXBound;

    public bool doMovement;

    public IEnumerator Movement()
    {
        while (doMovement)
        {
            transform.position += Vector3.right * xIncrementAmount * Time.deltaTime;

            foreach (Transform enemy in transform) // Loop through all children of the enemy holder without creating a list.
            {
                if (enemy.position.x <= minXBound || enemy.position.x >= maxXBound)
                {
                    xIncrementAmount = -xIncrementAmount;
                    transform.position = new Vector3(transform.position.x, transform.position.y - yDropAmount);
                    yield return null;
                }

                if(enemy.position.y <= -3.51f && !GameManager.instance.gameOver)
                {
                    GameManager.instance.EndGame();
                    Debug.Log("GameOver");
                }

            }
            yield return new WaitForSeconds(enemyMoveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TransportShip") || other.CompareTag("Bottom"))
        {
            Debug.Log("GameOver");
            GameManager.instance.EndGame();
        }
    }
}
