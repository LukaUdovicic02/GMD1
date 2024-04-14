using System;
using System.Collections;
using Game;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public AudioManager audioManager;
    [SerializeField] private string destroyableObjectName;

    public GameObject explosionAnimation;
    private float explosionDuration = 0.25f;
    public bool isExploded;

    private IDamagable takeDMG;

    private void Update()
    {
        Collider2D[] coliiderArray = Physics2D.OverlapCircleAll(transform.position, 2);
        foreach (Collider2D collider in coliiderArray)
        {
            if (collider.gameObject.CompareTag("Player 1"))
            {
                if (isExploded)
                {
                    Debug.Log("test1");
                    takeDMG.TakeDamage(30);
                    isExploded = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            if (destroyableObjectName.Equals("glass"))
            {
                audioManager.PlaySFX(audioManager.glassShattering);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }

            if (destroyableObjectName.Equals("wood"))
            {
                audioManager.PlaySFX(audioManager.doorBreaking);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }

            if (destroyableObjectName.Equals("barrel"))
            {
                isExploded = true;
                StartCoroutine(PlayExplosionAndDestroy());
                Destroy(other.gameObject);
            }
        }
    }

    private IEnumerator PlayExplosionAndDestroy()
    {
        explosionAnimation.SetActive(true);
        yield return new WaitForSeconds(explosionDuration);
        explosionAnimation.SetActive(false);
        isExploded = false;
        Destroy(gameObject);
    }
}