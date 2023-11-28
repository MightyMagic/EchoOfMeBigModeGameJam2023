using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerModel;

    public Rigidbody rigidBody;

    [Header("Movement")]
    public float moveSpeed;
    public float rotationSpeed;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeigth;
    public LayerMask Ground;
    bool isGrounded;

    float horizontalInput;
    float verticalInput;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }

    void Update()
    {
        // capture player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeigth * 0.5f + 0.2f, Ground);
        if (isGrounded)
            rigidBody.drag = groundDrag;
        else
            rigidBody.drag = 0;

        // speed control
        Vector3 flatVelocity = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);
        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rigidBody.velocity = new Vector3(limitedVelocity.x, rigidBody.velocity.y, limitedVelocity.z);
        }

    }

    private void FixedUpdate()
    {
        // calculate movement direction
        Vector3 moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // move player in the calculated direction
        rigidBody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // rotate player towards the direction the camera is pointing to
        if (moveDirection != Vector3.zero)
        {
            playerModel.forward = Vector3.Slerp(playerModel.forward, moveDirection.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}