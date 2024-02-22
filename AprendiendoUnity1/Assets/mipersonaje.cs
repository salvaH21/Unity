using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class mipersonaje : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotateSpeed = 3.0f;
    public float jumpSpeed = 8.0f;
    public float doubleJumpSpeed = 8.0f; // Velocidad de segundo salto
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private bool doubleJumpUsed = false; // Controlar el doble salto

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // Resetear el doble salto cuando esta en el suelo
            doubleJumpUsed = false;

            // Rotate around y-axis
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

            // Move forward/backward
            moveDirection = transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed; // Apply jump velocity
            }
        }
        else
        {
            // Si no esta en el suelo y se pulsa el botón de salto y el doble salto no se ha usado
            if (Input.GetButtonDown("Jump") && !doubleJumpUsed)
            {
                // Segundo salto
                moveDirection.y = doubleJumpSpeed;
                doubleJumpUsed = true; // Marcar el doble salto como utilizado
            }
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
