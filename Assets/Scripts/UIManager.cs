using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject gameOverPanel;
    public GameObject winPanel;
    private GameObject currentIcon;

    public List<GameObject> healthIcons = new List<GameObject>();

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

    public void HideHealth(int playerHealthIndex)
    {
        switch(playerHealthIndex)
        {
            case 2:
                healthIcons[2].gameObject.SetActive(false);
                break;
            case 1:
                healthIcons[1].gameObject.SetActive(false);
                break;
            case 0:
                foreach (GameObject healthIcon in healthIcons)
                {
                    if(healthIcon.activeSelf != false)
                    {
                        healthIcon.SetActive(false);
                    }
                }
                break;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
