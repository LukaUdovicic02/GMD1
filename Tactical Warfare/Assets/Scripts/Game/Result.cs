using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Health player1Health;
    public Health player2Health;
    public TextMeshProUGUI winnerText;
    public Button playAgainButton;
    public Button mainMenuButton;
    private bool isPlayAgainButtonSelected = true;
    private bool gameIsOver = false;

    public GameObject player1; // Assign your player 1 object
    public GameObject player2; // Assign your player 2 object

    void Update()
    {
        DisplayWinner();

        if (gameIsOver)
        {
            HandleInput();
        }
    }

    void DisplayWinner()
    {
        if (player1Health.currentHealth <= 0 && !gameIsOver)
        {
            SetWinnerText("Player 2 wins!");
            ActivateGameOverScreen();
        }
        else if (player2Health.currentHealth <= 0 && !gameIsOver)
        {
            SetWinnerText("Player 1 wins!");
            ActivateGameOverScreen();
        }
    }

    void SetWinnerText(string text)
    {
        winnerText.text = text;
    }

    void ActivateGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        gameIsOver = true;
        player1.SetActive(false); // Deactivate player 1
        player2.SetActive(false); // Deactivate player 2
        SelectPlayAgainButton();
    }

    void HandleInput()
    {
        // Check if button 0 is pressed on any joystick
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (isPlayAgainButtonSelected)
            {
                PlayAgain();
            }
            else
            {
                Exit();
            }
        }

        // Check if joystick D-pad or axis is used to navigate between buttons
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0.5f || horizontal < -0.5f)
        {
            ToggleButtonSelection();
        }
    }

    private void SelectPlayAgainButton()
    {
        isPlayAgainButtonSelected = true;
        playAgainButton.Select();
    }

    private void SelectMainMenuButton()
    {
        isPlayAgainButtonSelected = false;
        mainMenuButton.Select();
    }

    private void ToggleButtonSelection()
    {
        if (isPlayAgainButtonSelected)
        {
            SelectMainMenuButton();
        }
        else
        {
            SelectPlayAgainButton();
        }
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
