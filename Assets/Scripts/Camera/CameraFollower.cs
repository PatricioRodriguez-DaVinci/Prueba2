using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform _target;

    [Header("Values")]
    [Range(0f, 1f)] [SerializeField] private float _smoothSpeed = .125f; //Limita seleccion del editor

    Vector3 _offset;

    private void Awake()
    {
        _offset = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPos = _target.position + _offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, _smoothSpeed);
        transform.position = smoothedPos;
    }

}
