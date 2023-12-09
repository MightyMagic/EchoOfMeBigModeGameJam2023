using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SimpleMouseAndKeyboardMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Camera playerCamera;
    [SerializeField] LayerMask groundMask;

    [Header("Internal")]
    Rigidbody rb;
    float mouseX;
    float horizontalInput;
    float verticalInput;

    Vector3 cameraOffset;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraOffset = playerCamera.transform.position - this.transform.position;


        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // capture player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 inputVector = (transform.forward * verticalInput + transform.right * horizontalInput).normalized * moveSpeed;

        rb.velocity = new Vector3(inputVector.x, rb.velocity.y, inputVector.z);

        //RotatePlayerTowardsMouse();

        RotateWithMouse();
    }

    private void LateUpdate()
    {
        //playerCamera.transform.position = cameraOffset + this.transform.position;
    }

    // Doesn't work as I expected and I don't know how to fix it yet
    void RotatePlayerTowardsMouse()
    {

       Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
       if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, groundMask))
        {
            print("Hit!");
            Vector2 direction = new Vector2(raycastHit.point.x - transform.position.x, raycastHit.point.z - transform.position.z);
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            rb.rotation= targetRotation;
            //rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime));
        }
    }

    void RotateWithMouse()
    {
        mouseX += Input.GetAxis("Mouse X");

        rb.rotation = Quaternion.Euler(new Vector3(0f, mouseX * rotationSpeed, 0));
    }
}
