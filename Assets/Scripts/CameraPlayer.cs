using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 cameraOffset = new Vector3(0, 10, -10); // ajustar según la altura y el ángulo de la cámara

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        smoothedPosition.y = transform.position.y; // asegurarse de que la cámara no cambie de altura
        transform.position = smoothedPosition;
    }
}
