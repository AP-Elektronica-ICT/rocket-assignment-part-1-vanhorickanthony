using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject ScoreboardCanvas;
    public GameObject GameOverCanvas;

    private Health playerHealth;
    
    public enum GameStates
    {
        Playing,
        GameOver,
    }

    public GameStates gameState = GameStates.Playing;
    
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }

        playerHealth = Player.GetComponent<Health>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameStates.Playing:

                if (!playerHealth.isAlive)
                {
                    gameState = GameStates.GameOver;
                    ScoreboardCanvas.SetActive(false);
                    GameOverCanvas.SetActive(true);
                }

                break;
        }
    }
}
