using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : Enemy
{
    public float minDistance = 1.0f;
    public float maxDistance = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 5.0f;
        life = 1;
    }

    void FixedUpdate()
    {
        // calcula distancia entre enemigo y jugador
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        // si la distancia esta entre el minimo y maximo, lo persigue
        if (distance > minDistance && distance <= maxDistance)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // chequea si choco al jugador (con Tag "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Lo choca");
            player.TakeDamage(1);
            TakeDamage(9);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Recibir daño");
            TakeDamage(1);
        }
    }
}
