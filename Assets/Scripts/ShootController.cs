using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class ShootController : MonoBehaviour
{
    private InputController _inputController;

    private void Start()
    {
        _inputController = GetComponent<InputController>();
    }

    void LateUpdate()
    {
        if(_inputController.isShooting)
        {
            Debug.Log("Disparar");
        }
    }
}
