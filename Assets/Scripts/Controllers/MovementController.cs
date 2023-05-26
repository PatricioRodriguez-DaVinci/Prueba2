using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InputController))]
public class MovementController : MonoBehaviour
{
    [Header("---------- Movement Values ----------\n")]
    [SerializeField] private float _movementSpeed = 5f;
    [Range(1f, 5f)] [SerializeField] private float _sprintMod = 1.5f;
    [Range(0.1f, 0.9f)] [SerializeField] private float _backMod = 0.5f;

    private float _backAux;
    private Rigidbody _rb;
    private InputController _inputController;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _inputController = GetComponent<InputController>();
        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

    }

    private void FixedUpdate()
    {
        if (_inputController.xAxis != 0 || _inputController.zAxis != 0)
        {
            Movement(_inputController.xAxis, _inputController.zAxis);
        }
    }

    private void Movement(float xAxis, float zAxis)
    {
        Vector3 dir = (transform.right * xAxis + transform.forward * zAxis).normalized;

        if (zAxis < 0) //Caminar hacia atr�s
        {
            _backAux = _backMod;
        }

        if ((_inputController.isRunning) && zAxis > 0 && xAxis <= 0) //Sprint hacia adelante
        {
            _rb.MovePosition(transform.position += dir * (_movementSpeed * _sprintMod) * Time.fixedDeltaTime);
        }

        else //Caminar normal
        {
            _rb.MovePosition(transform.position += dir * _movementSpeed * _backAux * Time.fixedDeltaTime);
            _backAux = 1f;
        }
    }
}
