using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float playerSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    private Vector2 mousePos;
    private Vector2 movement;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");

        mousePos = cam.WorldToScreenPoint(Input.mousePosition);
        // transform.Translate(movement * playerSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}