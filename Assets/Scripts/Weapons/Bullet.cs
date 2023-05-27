using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float forceSpeed = 10f;

    private Rigidbody rb;

    private void Awake()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * forceSpeed, ForceMode.Impulse);

        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
