using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1000f; // the speed of rotation

    // Update is called once per frame
    void Update()
    {
        // Get the position of the mouse pointer in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Create a ray from the camera through the mouse pointer
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        // Create a plane at the object's position with its normal facing the camera
        Plane plane = new Plane(Vector3.up, transform.position);

        // Calculate the distance from the ray origin to the plane
        float distance;
        plane.Raycast(ray, out distance);

        // Calculate the position of the mouse pointer in world space
        Vector3 mousePositionWorld = ray.GetPoint(distance);

        // Calculate the direction from the object's position to the mouse position
        Vector3 direction = mousePositionWorld - transform.position;

        // Calculate the angle between the direction and the Y-axis
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Calculate the rotation around the Y-axis that points in the direction of the mouse pointer
        Quaternion rotation = Quaternion.Euler(0f, angle, 0f);

        // Smoothly rotate the object attached to this script towards the desired rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }
}
