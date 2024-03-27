using System;
using Game;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed = 300f;

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
            other.gameObject.GetComponent<IDamagable>().TakeDamage(10);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player 2"))
        {
            other.gameObject.GetComponent<IDamagable>().TakeDamage(10);
            Destroy(gameObject);
        }
    }
}