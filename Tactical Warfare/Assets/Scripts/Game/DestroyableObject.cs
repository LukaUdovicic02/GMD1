using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public AudioManager audioManager;
    [SerializeField] private string destroyableObjectName;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            if (destroyableObjectName.Equals("glass"))
            {
                audioManager.PlaySFX(audioManager.glassShattering);
            }

            if (destroyableObjectName.Equals("wood"))
            {
                audioManager.PlaySFX(audioManager.doorBreaking);
            }

            Destroy(gameObject);
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}