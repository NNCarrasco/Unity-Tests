using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    public Text scoreText;
    public int playerScore;
    public GameObject gameOverScreen;
    public int currentLevel = 1;

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
        LevelUpLogic();
    }

    private void LevelUpLogic()
    {
        if (playerScore % 10 == 0)
        {
            currentLevel++;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("00 - Game Selector");
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
