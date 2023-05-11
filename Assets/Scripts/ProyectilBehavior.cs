using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilBehavior : MonoBehaviour
{
    public float waitTime = 2.0f;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Destroy(gameObject);
            timer = 0f;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        



    }
}
