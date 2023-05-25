using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [Header("---------- Movement Imputs ----------\n")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode reloadKey = KeyCode.R;

    public JumpController jumpController;

    public float xAxis, zAxis;

    public bool isJumping = false;
    public bool isRunning = false;
    public bool isShooting = false;
    public bool isReloading = false;

    void Awake()
    {
        jumpController = GetComponent<JumpController>();
    }
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(jumpKey) && jumpController._isGrounded) isJumping = true;
        if (Input.GetKey(runKey)) isRunning = true; else isRunning = false;
        if (Input.GetMouseButton(0)) isShooting = true; else isShooting = false;
        if (Input.GetKeyDown(reloadKey)) isReloading = true;
    }
}
