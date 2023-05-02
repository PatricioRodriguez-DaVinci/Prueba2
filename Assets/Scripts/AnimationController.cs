using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(InputController))]

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private InputController _inputController;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _inputController = GetComponent<InputController>();
    }

    private void FixedUpdate()
    {
        if (_inputController.xAxis != 0 || _inputController.zAxis != 0)
        {
            _animator.SetFloat("xSpeed", _inputController.xAxis);
            _animator.SetFloat("zSpeed", _inputController.zAxis);
        }

        else
        {
            _animator.SetFloat("xSpeed", 0f);
            _animator.SetFloat("zSpeed", 0f);
        }

        if ((_inputController.isRunning) && _inputController.zAxis > 0 && _inputController.xAxis <= 0)
        {
            _animator.SetFloat("zSpeed", _inputController.zAxis);
        }

        _animator.SetBool("isShooting", _inputController.isShooting);
        /*
        if (_inputController.isShooting)
        {
            _animator.SetBool("isShooting", true);
        }

        else
        {
            _animator.SetBool("isShooting", false);
        }*/


    }
}
