using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 250f;
    public Ability ability;

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
        if (ability.isDashing) return;

        movement.y = Input.GetAxisRaw(InputNameVertical);
        movement.x = Input.GetAxisRaw(InputNameHorizontal);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        offset = (mousePos - (Vector2) transform.position).normalized * offsetDistance;

        if (Input.GetKeyDown(KeyCode.E) && !ability.isDashing)
        {
            ability.Dash();
        }

        if (Input.GetKeyDown(KeyCode.T) && !ability.isInvisible)
        {
            ability.Invisible();
        }
    }

    private void FixedUpdate()
    {
        if (ability.isDashing) return;

        rb.velocity = (movement * playerSpeed * Time.fixedDeltaTime);
        rb.angularVelocity = 0;
        Vector2 lookDirection = (mousePos - rb.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}