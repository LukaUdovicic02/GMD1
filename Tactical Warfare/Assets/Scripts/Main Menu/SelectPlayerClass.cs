using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayerClass : MonoBehaviour
{
    private int currentPlayer = 1;

    public void SelectAssassin()
    {
        PlayerPrefs.SetString($"SelectedClassPlayer{currentPlayer}", "Assassin");
        NextPlayer();
    }

    public void SelectAssault()
    {
        PlayerPrefs.SetString($"SelectedClassPlayer{currentPlayer}", "Assault");
        NextPlayer();
    }

    public void SelectHunter()
    {
        PlayerPrefs.SetString($"SelectedClassPlayer{currentPlayer}", "Hunter");
        NextPlayer();
    }

    private void NextPlayer()
    {
        if (currentPlayer == 1)
        {
            currentPlayer = 2;
        }
        else
        {
            SceneManager.LoadSceneAsync(1); 
        }
    }
}
