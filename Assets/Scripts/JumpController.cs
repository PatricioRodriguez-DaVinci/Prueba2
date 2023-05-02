using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InputController))]
public class JumpController : MonoBehaviour
{
    [Header("---------- Jump Values ----------\n")]
    [SerializeField] private float _jumpForce = 2f;

    private Rigidbody _rb;
    private InputController _inputController;
    private bool _isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _inputController = GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputController.isJumping && _isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _inputController.isJumping = false;
        }
    }
}
