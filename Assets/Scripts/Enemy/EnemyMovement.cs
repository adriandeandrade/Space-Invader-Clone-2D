using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed;

    public bool doMovement;

    private void Start()
    {

    }

    public IEnumerator Movement()
    {
        while (doMovement)
        {
            transform.position += Vector3.right * enemySpeed * Time.deltaTime;

            foreach (Transform enemy in transform)
            {
                if (enemy.position.x <= -4.70f || enemy.position.x >= 4.70f)
                {
                    enemySpeed = -enemySpeed;
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f);
                    yield return null;
                }
                // TODO: GameOver
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
