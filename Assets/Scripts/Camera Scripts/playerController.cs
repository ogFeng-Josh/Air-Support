using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    //Data Declaration
    public float mouseSense = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        //Sets Cursor to center of screen and hides it
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    
    void Update()
    {
        //Gets Input of Mouse Movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        xRotation -= mouseY; //Decrease X Rotation based on our Mouse Y because + flips it
        yRotation -= mouseX; //set debug log incase to take input

        xRotation = Mathf.Clamp(xRotation, 15f, 60f); //Clamping Rotation of Y Player's Control
        yRotation = Mathf.Clamp(yRotation, 0f, 100f);
        //Set up y rotation variable - yRotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, yRotation); //Keep track of X Rotation (Rotations)

        playerBody.Rotate(Vector3.up * mouseX); //Specify Access to rotate around

    }
}
