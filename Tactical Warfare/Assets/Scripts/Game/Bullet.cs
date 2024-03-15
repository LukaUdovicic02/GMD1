using System;
using Game;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed = 10f;

    void Start()
    {
        rb.velocity = transform.up * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Top"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player 1"))
        {
            // Destroy(other.gameObject);
            other.gameObject.GetComponent<IDamagable>().TakeDamage(10);
            Debug.Log("ficko");
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player 2"))
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<IDamagable>().TakeDamage(10);
            Debug.Log("ficko2");

            Destroy(gameObject);
        }
    }
}