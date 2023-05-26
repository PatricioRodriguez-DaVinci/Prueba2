using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public float moveSpeed = 5.0f;
    public Transform playerTransform;
    protected Rigidbody rb;
    public Player player;

    private void Awake()
    {
        // Verifica que tenga Rigidbody, sino, le asigna uno.

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    
        // Busca el GameObject con el nombre "Player" y asigna su transform a la variable "player"

        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
            player = playerObject.GetComponent<Player>();
        }
        else
        {
            Debug.LogError("No se encuentra el GameObject con nombre -Player- en la escena.");
        }
    }

}
