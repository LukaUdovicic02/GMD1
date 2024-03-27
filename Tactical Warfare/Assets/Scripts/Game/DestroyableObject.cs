using System.Collections;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public AudioManager audioManager;
    [SerializeField] private string destroyableObjectName;

    public GameObject explosionAnimation;
    private float explosionDuration = 0.25f;

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
        Destroy(gameObject);
    }
}