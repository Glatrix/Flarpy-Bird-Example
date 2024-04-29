using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    // Raw Player Score
    public int playerScore;
    // Reference to GUI.Text located in Game Canvas
    public Text scoreText;
    // Game Over Screen object in Game Canvas (inactive by default)
    public GameObject gameOverScreen;
    // the "New High Score!" text on game end
    public GameObject newHighScoreText;
    // Pause Screen object in Game Canvas (inactive by default)
    public GameObject pauseScreen;
    // Our Bird Reference
    public BirdScript player;

    // Menus
    private bool isPaused = false;
    private bool isGameOver = false;
    private bool isNewHighScore = false;

    private void Update()
    {
        // If Escape was pressed, handle pause / restart
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // We should not be able to pause
            // if its game over screen.
            if (gameOverScreen.activeSelf)
            {
                // Restart Game Scene
                RestartGame();
            }
            else
            {
                // Game Not Over, Pause normally
                // so we can unpause and keep going!
                PauseGame();
            }
        }
    }

    // Increase Score by (scoreToAdd) ammount.
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (!isGameOver)
        {
            // Handle adding to raw score +
            // changing scoreText.
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            HighScoreCheck();
        }
    }

    // Handle Restart Game
    public void RestartGame()
    {
        // Load Current Scene Over Again
        // (yes I know technically I could just
        // do current scene .name)
        SceneManager.LoadScene("Game Scene");
        isGameOver = true;
    }

    // Handle Game Over
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        newHighScoreText.SetActive(isNewHighScore);
        isGameOver = true;
        player.gameObject.GetComponent<Rigidbody2D>().AddTorque(-5.0f, ForceMode2D.Impulse);
    }

    // Handle Pause Game
    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            // We set time scale to 0 to freeze game in place.
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        } 
    }

    // Handle Unpause Game
    public void UnPauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
            // We set time scale to 1 to unfreeze game.
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }

    // Unfreeze game if frozen from Pause or other
    // menu
    public void EnsureGameNotFrozen()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    // Load Main Menu Scene
    public void ReturnToMenu()
    {
        EnsureGameNotFrozen();
        SceneManager.LoadScene("Main Menu Scene");
    }

    public void HighScoreCheck()
    {
        // If score not saved, or saved score is less than current score
        if (!PlayerPrefs.HasKey("highscore") || PlayerPrefs.GetInt("highscore") < playerScore)
        {
            // save score
            PlayerPrefs.SetInt("highscore", playerScore);
            isNewHighScore = true;
        }
    }
}
