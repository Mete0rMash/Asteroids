using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private int asteroidCount;
    private int lives;

    private bool winCon;

    public Text asteroidText;
    public Text livesText;
    public Text loseText;
    public Text winText;

    [SerializeField] public Asteroid asteroid;

    private void Awake()
    {
        BeginGame();
    }

    void BeginGame()
    {
        asteroidCount = 0;
        lives = 3;

        winCon = false;

        asteroidText.text = "SCORE:" + asteroidCount;
        livesText.text = "LIVES: " + lives;
    }

    public void IncrementScore()
    {
        asteroidCount++;

        asteroidText.text = "SCORE:" + asteroidCount;

        if (asteroidCount == 20)
        {
            winText.text = "YOU WIN";
            winCon = true;
        }

        if (winCon && Input.GetKey(KeyCode.R))
        {
            BeginGame();
        }
    }

    public void DecrementLives()
    {
        lives--;
        livesText.text = "LIVES: " + lives;

        if (lives < 1)
        {
            loseText.text = "YOU LOSE";

            if (Input.GetKey(KeyCode.R))
            {
                BeginGame();
            }
        }
    }

    void Update()
    {
    }
}
