using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private ICollectableBehaviour _collectableBehaviour;

    private void Awake()
    {
        _collectableBehaviour = GetComponent<ICollectableBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player1 = other.GetComponent<PlayerMovement>();

        if (player1 != null)
        {
            _collectableBehaviour.OnCollected(player1.gameObject);
            Destroy(gameObject);
            
        }
    }
}