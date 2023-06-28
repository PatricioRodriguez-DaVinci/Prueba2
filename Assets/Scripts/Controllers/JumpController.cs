/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InputController))]
public class JumpController : MonoBehaviour
{
    [Header("---------- Jump Values ----------\n")]
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _raycastDistance = 0.25f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _raycastOrigin;

    private Rigidbody _rb;
    private InputController _inputController;
    public bool _isGrounded = true;

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

        // Perform the raycast to check if grounded
        RaycastHit hit;
        if (Physics.Raycast(_raycastOrigin.position, Vector3.down, out hit, _raycastDistance, _groundLayer))
        {
            _isGrounded = true; // Set _isGrounded to true if the raycast hits the ground
        }
        else
        {
            _isGrounded = false; // Set _isGrounded to false if the raycast doesn't hit the ground
        }
    }
}
*/