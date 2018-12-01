using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    private float cooldown;
    private float nextShotTimeBullet;
    private float nextShotTimeExplosive;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (weaponSystem.currentFireMode == WeaponSystem.FireMode.BULLET)
        {
            if (Time.time > nextShotTimeBullet)
            {
                GameObject bullet = Instantiate(currentProjectilePrefab, shootPoint.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("Shoot");
                Destroy(bullet, 5.0f);

                nextShotTimeBullet = Time.time + weaponSystem.currentGunType.shotCooldown;
            }
        }
        else if (weaponSystem.currentFireMode == WeaponSystem.FireMode.EXPLOSIVE)
        {
            if (Time.time > nextShotTimeExplosive)
            {
                GameObject bullet = Instantiate(currentProjectilePrefab, shootPoint.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("Shoot2");
                Destroy(bullet, 5.0f);

                nextShotTimeExplosive = Time.time + weaponSystem.currentGunType.shotCooldown;
            }
        }



    }

    private void UpdateProjectile(GunType gunType)
    {
        currentProjectilePrefab = gunType.projectilePrefab;
        cooldown = gunType.shotCooldown;
        print("Updated projectile prefab");
    }
}
