using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Type", menuName = "Weapons/Gun Type")]
public class GunType : ScriptableObject
{
    public int damage;
    public int damageRange; // The range which the bullet will deal damage.
    public GameObject projectilePrefab;
    public float shotCooldown;
}
