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
    [SerializeField] public List<GameObject> enemies;

    [HideInInspector] public int enemiesLeft;
    [HideInInspector] public int shipsLeft;
    [HideInInspector] public bool playerAlive;
    [HideInInspector] public bool gameOver = false;

    private void Awake()
    {
        weaponSystem = FindObjectOfType<PlayerController>().GetComponent<WeaponSystem>();
    }

    private void Start()
    {
        playerAlive = true;
        shipsLeft = 3;
    }

    private void Update()
    {
        if(shipsLeft <= 0 && !gameOver)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        gameOver = true;
        playerAlive = false;
        UIManager.instance.gameOverPanel.SetActive(true);
    }

    public void WinGame()
    {
        gameOver = true;
        UIManager.instance.winPanel.SetActive(true);
    }
}
