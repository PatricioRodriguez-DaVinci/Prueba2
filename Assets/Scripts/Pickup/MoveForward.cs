using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 30f;    

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
