using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodrisa : MonoBehaviour
{
    public float radius = 2f;
    public float speed = 2f;
    private Vector3 centerPosition;
    private float time = 0f;

    void Start()
    {
        centerPosition = transform.position;
    }

    void Update()
    {
        time += Time.deltaTime;
        float x = Mathf.Sin(time * speed) * radius;
        float y = 0f;
        float z = Mathf.Cos(time * speed) * radius;
        transform.position = centerPosition + new Vector3(x, y, z);
        transform.rotation = Quaternion.LookRotation(-new Vector3(x, y, z));
    }
}
