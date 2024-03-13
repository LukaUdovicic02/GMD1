using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    private Vector2 mousePos;
    private Vector2 movement;

    public float offsetDistance = 1f;
    private Vector2 offset;

    void Update()
    {
        movement.y = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        offset = (mousePos - (Vector2)transform.position).normalized * offsetDistance;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);

        Vector2 lookDirection = (mousePos - rb.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}