using System.Collections;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Rigidbody2D rb;

    [Header("------- Dash settings -------")]
    [SerializeField] float dashSpeed = 100f;
    [SerializeField] float dashDuration = 0.1f; 
    private bool isDashing;

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
        Vector2 dashDirection = Vector2.down;
        rb.velocity = dashDirection * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        rb.velocity = Vector2.zero;
        isDashing = false;
    }
}