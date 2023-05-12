using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5.0f;
    public float minDistance = 1.0f;
    public float maxDistance = 10.0f;
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

        // Busca el GameObject con el nombre "Player" y asigna su transform a la variable "player"
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró el GameObject con nombre \"Player\" en la escena.");
        }
    }

    void FixedUpdate()
    {
        // calcula distancia entre enemigo y jugador
        float distance = Vector3.Distance(transform.position, player.position);

        // si la distancia está entre el mínimo y máximo, lo persigue
        if (distance > minDistance && distance <= maxDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // chequea si chocó al jugador (con Tag "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Lo choca");
            Destroy(gameObject);
        }
    }
}
