using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;

    private GameObject currentProjectilePrefab;

    private WeaponSystem weaponSystem;

    private void OnEnable()
    {
        WeaponSystem.OnFireModeChanged += UpdateProjectile;
    }

    private void Start()
    {
        weaponSystem = GetComponent<WeaponSystem>();
        currentProjectilePrefab = weaponSystem.currentGunType.projectilePrefab;
    }

    private void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(currentProjectilePrefab, shootPoint.position, Quaternion.identity);
        Destroy(bullet, 5.0f);
    }

    private void UpdateProjectile(GunType gunType)
    {
        currentProjectilePrefab = gunType.projectilePrefab;
        print("Updated projectile prefab");
    }
}
