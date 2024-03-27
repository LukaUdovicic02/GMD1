using System.Collections;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Rigidbody2D rb;

    [Header("------- Invincibility settings -------")]
    public Health health;

    public bool isInvisible;
    public SpriteRenderer playerRenderer;
    private Color originalColor;

    [Header("------- Dash settings -------")] [SerializeField]
    float dashSpeed = 30f;

    [SerializeField] float dashDuration = 0.3f;
    public bool isDashing;

    private void Start()
    {
        originalColor = playerRenderer.color;
    }

    private void Update()
    {
        if (isDashing) return;
        if (isInvisible) return;
    }

    public void Invisible()
    {
        if (!isInvisible)
        {
            StartCoroutine(PerformInvincibility());
        }
    }

    private IEnumerator PerformInvincibility()
    {
        isInvisible = true;

        Color tempColor = playerRenderer.color;
        tempColor.a = 0.5f;
        playerRenderer.color = tempColor;

        float invincibilityDuration = 3f;
        float timer = 0f;

        while (timer < invincibilityDuration)
        {
            timer += Time.deltaTime;
            health.currentHealth = health.maxHealth;
            yield return null;
        }

        isInvisible = false;
        playerRenderer.color = originalColor;
    }


    public void Dash()
    {
        if (!isDashing)
        {
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        isDashing = true;
        rb.velocity = playerMovement.movement * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        rb.velocity = Vector2.zero;
        isDashing = false;
    }
}