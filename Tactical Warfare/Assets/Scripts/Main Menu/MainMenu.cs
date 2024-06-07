using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioSource Source;
    public Button readyButton;
    public Button quitButton;
    private bool isReadyButtonSelected = true;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        Source.Play();
        SelectReadyButton();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (isReadyButtonSelected)
            {
                PlayGame();
            }
            else
            {
                QuitGame();
            }
        }

        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0.5f || horizontal < -0.5f || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            ToggleButtonSelection();
        }
    }

    private void SelectReadyButton()
    {
        isReadyButtonSelected = true;
        readyButton.Select();
    }

    private void SelectQuitButton()
    {
        isReadyButtonSelected = false;
        quitButton.Select();
    }

    private void ToggleButtonSelection()
    {
        if (isReadyButtonSelected)
        {
            SelectQuitButton();
        }
        else
        {
            SelectReadyButton();
        }
    }
}