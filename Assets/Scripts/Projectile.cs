using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private void Update()
    {
        transform.Translate(transform.up * bulletSpeed * Time.deltaTime);
    }
}
