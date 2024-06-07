using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float defaultPlayerSpeed = 250f;
    [SerializeField] private float defaultCameraSpeed = 5f;
    public Ability ability;
    public Rigidbody2D rb;
    public Camera playerCamera;
    private Vector2 mousePos;
    public Vector2 movement;
    public float offsetDistance = 1f;
    private Vector2 offset;
    [FormerlySerializedAs("dashName")] public string abilityName;

    public Image crosshairImage;
    private Vector2 joystickPos;

    private float playerSpeed;
    private float cameraSpeed;

    private void Start()
    {
        string selectedClass = PlayerPrefs.GetString("SelectedClass" + gameObject.name, "Assassin");
        switch (selectedClass)
        {
            case "Assault":
                playerSpeed = defaultPlayerSpeed * 1.1f;
                break;
            case "Hunter":
                playerSpeed = defaultPlayerSpeed * 0.8f;
                break;
            case "Assassin":
                playerSpeed = defaultPlayerSpeed * 1.25f;
                break;
            default:
                playerSpeed = defaultPlayerSpeed;
                break;
        }

        cameraSpeed = defaultCameraSpeed;
        joystickPos = crosshairImage.transform.position;
        Cursor.visible = false;

        Debug.Log(selectedClass);
    }

    void Update()
    {
        if (ability.isDashing) return;

        float joystickX = 0f;
        float joystickY = 0f;
        float dash = 0f;
        float invisible = 0f;

        if (CompareTag("Player 1"))
        {
            movement.y = Input.GetAxisRaw("Vertical");
            movement.x = Input.GetAxisRaw("Horizontal");

            joystickX = Input.GetAxis("Joystick X");
            joystickY = Input.GetAxis("Joystick Y");

            abilityName = "Dash";
            dash = Input.GetAxis(abilityName);
        }
        else if (CompareTag("Player 2"))
        {
            movement.y = Input.GetAxisRaw("Vertical 2");
            movement.x = Input.GetAxisRaw("Horizontal 2");

            joystickX = Input.GetAxis("Joystick X2");
            joystickY = Input.GetAxis("Joystick Y2");
            abilityName = "Invisible";
            invisible = Input.GetAxis(abilityName);
        }

        Debug.Log($"JoystickX: {joystickX}, JoystickY: {joystickY}, Dash: {dash}, DashName: {abilityName}");

        joystickPos.x += joystickX * Time.deltaTime * 300;
        joystickPos.y += joystickY * Time.deltaTime * 300;

        joystickPos.x = Math.Clamp(joystickPos.x, 0, playerCamera.pixelWidth);
        joystickPos.y = Math.Clamp(joystickPos.y, 0, playerCamera.pixelHeight);

        Vector3 joystickWorldPos = playerCamera.ScreenToWorldPoint(new Vector3(joystickPos.x, joystickPos.y));
        crosshairImage.transform.position = playerCamera.WorldToScreenPoint(joystickWorldPos);

        mousePos = playerCamera.ScreenToWorldPoint(joystickPos);

        if (dash > 0f && !ability.isDashing)
        {
            ability.Dash();
        }

        if (invisible > 0f && !ability.isInvisible)
        {
            ability.Invisible();
        }
    }

    private void FixedUpdate()
    {
        if (ability.isDashing) return;

        rb.velocity = movement * playerSpeed * Time.fixedDeltaTime;
        rb.angularVelocity = 0;

        Vector2 lookDirection = (mousePos - rb.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}