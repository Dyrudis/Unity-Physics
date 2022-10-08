using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitivity = 100f;
    [SerializeField] private Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        // Locks the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get the mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Set boundaries for the camera
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void OnDrawGizmos()
    {
        // Draw a line to represent the player's sight
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }
}
