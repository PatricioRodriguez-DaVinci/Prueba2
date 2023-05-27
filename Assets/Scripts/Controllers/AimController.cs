using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public Transform target;                    // The target object (player Transform)
    public Vector3 offset = new Vector3(0, 10, -8);   // The offset from the target position
    public float sensitivity = 2f;              // The mouse sensitivity for camera rotation
    public float minVerticalAngle = -30f;       // The minimum vertical angle of the camera
    public float maxVerticalAngle = -20f;        // The maximum vertical angle of the camera

    private float rotationX = 0f;

    void Start()
    {
        // Hide and lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // Get the horizontal and vertical inputs for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the target object (player) horizontally
        target.Rotate(Vector3.up, mouseX);

        // Calculate the vertical rotation of the camera
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);

        // Calculate the camera rotation based on the target's rotation
        Quaternion rotation = Quaternion.Euler(rotationX, target.eulerAngles.y, 0f);

        // Calculate the desired camera position
        Vector3 desiredPosition = target.position + rotation * offset;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.1f);

        // Make the camera look at the target object
        transform.LookAt(target);
    }
}
