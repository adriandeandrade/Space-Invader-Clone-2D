using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public enum FireMode { BULLET, EXPLOSIVE };
    public FireMode currentFireMode;

    [SerializeField] private GunType bulletGunType;
    [SerializeField] private GunType explosiveGunType;

    [HideInInspector] public GunType currentGunType;

    public delegate void FireModeChanged(GunType gunType);
    public static event FireModeChanged OnFireModeChanged;

    private void Start()
    {
        currentFireMode = FireMode.BULLET;
        currentGunType = bulletGunType;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchFireMode();
        }
    }

    private void SwitchFireMode()
    {
        switch(currentFireMode)
        {
            case FireMode.BULLET:
                currentFireMode = FireMode.EXPLOSIVE;
                currentGunType = explosiveGunType;
                UIManager.instance.SwitchIcon("Explosive");
                break;
            case FireMode.EXPLOSIVE:
                currentFireMode = FireMode.BULLET;
                currentGunType = bulletGunType;
                UIManager.instance.SwitchIcon("Bullet");
                break;
        }

        if (OnFireModeChanged != null)
        {
            OnFireModeChanged(currentGunType);
        }
    }
}
