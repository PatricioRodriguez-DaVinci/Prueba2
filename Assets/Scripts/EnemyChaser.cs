using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5.0f;
    public float minDistance = 1.0f;
    private Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        // calcula distancia entre enemigo y jugador
        float distance = Vector3.Distance(transform.position, player.position);

        // si la distancia en mayor al mínimo, lo persigue
        if (distance > minDistance) {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter(Collision collision) {
        // chequea si chocó al jugador (con Tag "Player")
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Lo choca");
            // Hace algo
        }
    }
}
