using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float gravity = -9.81f;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 60f; // Maximum vertical angle looking up and down
    
    private Vector3 velocity;

    private CharacterController controller;
    private float rotationX = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock cursor to center of screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

         if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f;
        }

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime + velocity * Time.deltaTime);

        // Jumping
        // if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        // {
        //     Vector3 jumpVector = new Vector3(0f, jumpForce, 0f);
        //     controller.Move(jumpVector * Time.deltaTime);
        // }

        // Mouse Aiming
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}


