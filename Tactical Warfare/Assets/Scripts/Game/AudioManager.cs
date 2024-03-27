using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------- Audio Source -------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;


    [Header("------- Audio Clip -------")]
    public AudioClip background;

    public AudioClip glassShattering;
    public AudioClip doorBreaking;
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
        
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
