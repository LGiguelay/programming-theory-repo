using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private float movementForce;
    [SerializeField] private GameObject head;

    private float yRotation;
    private float xRotation;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if(Mathf.Abs(sensitivity) < 0.001)
        {
            Debug.Log("Sensitivity is zero");
        }
        if (Mathf.Abs(movementForce) < 0.001)
        {
            Debug.Log("Movement Force is zero");
        }

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        MoveHead();
        GetDirectionInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetDirectionInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        Vector3 movingForce = Vector3.forward * verticalInput + Vector3.right * horizontalInput;
        movingForce = movingForce.normalized * movementForce;
        rb.AddRelativeForce(movingForce, ForceMode.Force);
    }

    private void MoveHead()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity; //horizontal head moving
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity; //vertical head moving

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
        head.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
