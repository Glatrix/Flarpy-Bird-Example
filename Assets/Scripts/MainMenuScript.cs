using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public TMP_Text highScoreText;

    // Start is called before the first frame update
    private void Start()
    {
        // Load HighScore text
        if (PlayerPrefs.HasKey("highscore"))
        {
            highScoreText.text = $"Your High Score: {PlayerPrefs.GetInt("highscore")}";
        }
    }

    // Note: This is NOT an override.
    // StartGame loads the Game Scene
    public void StartGame()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
