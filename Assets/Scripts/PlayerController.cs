using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed);
        Vector3 targetPos = new Vector3(Mathf.Clamp(xPos, -4.6f, 4.6f), -4.59f, 0f);
        transform.position = targetPos;
    }

}
