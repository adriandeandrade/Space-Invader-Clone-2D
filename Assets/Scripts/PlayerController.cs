using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed);
        float yPos = transform.position.y + (Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
        Vector3 targetPos = new Vector3(Mathf.Clamp(xPos, -4.6f, 4.6f), Mathf.Clamp(yPos, -4.6f, -3.0f), 0f);
        transform.position = targetPos;
    }
}
