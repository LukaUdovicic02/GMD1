using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 250f;
    [SerializeField] private float dashForce = 10f;
    [SerializeField] private float dashDuration = 2f;
    private bool isDashing = false;
    private Vector2 dashDirection;

    public Rigidbody2D rb;
    public Camera cam;
    private Vector2 mousePos;
    public Vector2 movement;
    public string InputNameHorizontal;
    public string InputNameVertical;
    public float offsetDistance = 1f;
    private Vector2 offset;

    void Update()
    {
        if (isDashing) return;

        movement.y = Input.GetAxisRaw(InputNameVertical);
        movement.x = Input.GetAxisRaw(InputNameHorizontal);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        offset = (mousePos - (Vector2) transform.position).normalized * offsetDistance;

        if (Input.GetKeyDown(KeyCode.E) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (isDashing) return;

        rb.velocity = (movement * playerSpeed * Time.fixedDeltaTime);
        rb.angularVelocity = 0;
        Vector2 lookDirection = (mousePos - rb.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    IEnumerator Dash()
    {
        isDashing = true;
        rb.velocity = movement * dashForce;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
}