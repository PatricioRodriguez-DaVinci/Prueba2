using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(InputController))]
public class MovementController
{
    [Header("---------- Movement Values ----------\n")]
    [SerializeField] private float _movementSpeed = 5f;
    [Range(1f, 5f)] [SerializeField] private float _sprintMod = 1.5f;
    [Range(0.1f, 0.9f)] [SerializeField] private float _backMod = 0.5f;

    private float _backAux;
    private InputController _inputController;
    private Rigidbody _rb;
    private Transform _transform;

    public MovementController(InputController ic, Rigidbody rb, Transform tf)
    {
        _inputController = ic;
        _rb = rb;
        _transform = tf;
    }

    public void ArtificialFixedUpdate()
    {
        if (_inputController.xAxis != 0 || _inputController.zAxis != 0)
        {
            Movement(_inputController.xAxis, _inputController.zAxis);
        }
    }

    private void Movement(float xAxis, float zAxis)
    {
        Vector3 dir = (_transform.right * xAxis + _transform.forward * zAxis).normalized;

        if (zAxis < 0) //Caminar hacia atras
        {
            _backAux = _backMod;
        }

        if ((_inputController.isRunning) && zAxis > 0 && xAxis <= 0) //Sprint hacia adelante
        {
            _rb.MovePosition(_transform.position += dir * (_movementSpeed * _sprintMod) * Time.fixedDeltaTime);
        }

        else //Caminar normal
        {
            _rb.MovePosition(_transform.position += dir * _movementSpeed * _backAux * Time.fixedDeltaTime);
            _backAux = 1f;
        }
    }
}
