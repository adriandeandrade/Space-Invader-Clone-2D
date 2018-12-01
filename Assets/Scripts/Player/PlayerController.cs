using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private float minXBound;
    [SerializeField] private float maxXBound;
    [SerializeField] private float minYBound;
    [SerializeField] private float maxYBound;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed);
        float yPos = transform.position.y + (Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
        Vector3 targetPos = new Vector3(Mathf.Clamp(xPos, minXBound, maxXBound), Mathf.Clamp(yPos, minYBound, maxYBound), 0f);
        transform.position = targetPos;
    }
}
