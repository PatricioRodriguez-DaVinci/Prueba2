using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(InputController))]

public class AnimationController
{
    private InputController _inputController;
    private Animator _animator;

    public AnimationController(InputController _inCon, Animator animator)
    {
        _inputController = _inCon;
        _animator = animator;
    }



    public void ArtificialFixedUpdate()
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
    }
}
