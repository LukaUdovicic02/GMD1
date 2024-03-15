using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        _source.Play();
    }

    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}