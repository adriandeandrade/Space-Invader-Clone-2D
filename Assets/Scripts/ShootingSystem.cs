using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    private float cooldown;
    private float nextShotTime;

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
        cooldown = weaponSystem.currentGunType.shotCooldown;
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
        if(Time.time > nextShotTime)
        {
            GameObject bullet = Instantiate(currentProjectilePrefab, shootPoint.position, Quaternion.identity);
            Destroy(bullet, 5.0f);

            nextShotTime = Time.time + weaponSystem.currentGunType.shotCooldown;
        }

        
    }

    private void UpdateProjectile(GunType gunType)
    {
        currentProjectilePrefab = gunType.projectilePrefab;
        cooldown = gunType.shotCooldown;
        print("Updated projectile prefab");
    }
}
