using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private GameObject head;

    private float yRotation;
    private float xRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if(Mathf.Abs(sensitivity) < 0.001)
        {
            Debug.Log("Sensitivity is zero");
        }
    }

    void Update()
    {
        MoveHead();   
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
