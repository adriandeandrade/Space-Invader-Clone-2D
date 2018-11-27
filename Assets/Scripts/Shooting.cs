using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;

    [SerializeField] private GameObject projectilePrefab;

    Quaternion turretRotation;

    private void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, turretRotation);
        Destroy(bullet, 5.0f);
    }
}
