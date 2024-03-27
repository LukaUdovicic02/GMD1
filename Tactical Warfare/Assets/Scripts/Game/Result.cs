using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class Result : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Health player1Health; 
    public Health player2Health; 
    public TextMeshProUGUI winnerText; 

    void Update()
    {
        DisplayWinner();
    }

    void DisplayWinner()
    {
        if (player1Health.currentHealth <= 0)
        {
            SetWinnerText("Player 2 wins!"); 
            gameOverScreen.SetActive(true); 
        }
        else if (player2Health.currentHealth <= 0)
        {
            SetWinnerText("Player 1 wins!"); 
            gameOverScreen.SetActive(true);
        }
    }

    void SetWinnerText(string text)
    {
        winnerText.text = text;
    }

    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Exit()
    {
        SceneManager.LoadSceneAsync(0);
    }
}