using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton

    public static UIManager uiManager;
    public static UIManager instance
    {
        get
        {
            if(!uiManager)
            {
                uiManager = FindObjectOfType<UIManager>();

                if(!uiManager)
                {
                    Debug.Log("No UI Manager found in the scene.");
                }
            }
            return uiManager;
        }
    }

    #endregion

    [SerializeField] private GameObject bulletIcon;
    [SerializeField] private GameObject explosiveIcon;

    private GameObject currentIcon;

    private void Start()
    {
        currentIcon = bulletIcon;
        bulletIcon.SetActive(true);
    }

    public void SwitchIcon(string iconName)
    {
        switch(iconName)
        {
            case "Bullet":
                if(currentIcon != bulletIcon)
                {
                    currentIcon = bulletIcon;
                    explosiveIcon.SetActive(false);
                    bulletIcon.SetActive(true);
                }
                break;
            case "Explosive":
                if (currentIcon != explosiveIcon)
                {
                    currentIcon = explosiveIcon;
                    bulletIcon.SetActive(false);
                    explosiveIcon.SetActive(true);
                }
                break;
            default:
                Debug.Log(iconName + " can not be found.");
                break;
        }
    }
}
