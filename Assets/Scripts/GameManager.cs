using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager gameManager;
    public static GameManager instance
    {
        get
        {
            if (!gameManager)
            {
                gameManager = FindObjectOfType<GameManager>();

                if (!gameManager)
                {
                    Debug.Log("No UI Manager found in the scene.");
                }
            }
            return gameManager;
        }
    }

    #endregion

    [HideInInspector] public WeaponSystem weaponSystem;

    private void Awake()
    {
        weaponSystem = FindObjectOfType<PlayerController>().GetComponent<WeaponSystem>();
    }

}
