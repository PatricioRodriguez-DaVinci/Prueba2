using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonNodrisa : MonoBehaviour
{
    public GameObject cannonballPrefab; // Prefab de la bala del cañón
    public float timeBetweenShots = 5f; // Tiempo entre cada disparo
    public float cannonballSpeed = 10f; // Velocidad de la bala del cañón
    private float timeSinceLastShot; // Tiempo transcurrido desde el último disparo

    void Start()
    {
        timeSinceLastShot = timeBetweenShots; // Inicializa el tiempo transcurrido desde el último disparo
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime; // Incrementa el tiempo transcurrido desde el último disparo
        if (timeSinceLastShot >= timeBetweenShots)
        {
            // Si ha pasado el tiempo suficiente desde el último disparo, dispara una bala del cañón
            Fire();
            timeSinceLastShot = 0f; // Reinicia el tiempo transcurrido desde el último disparo
        }
    }

    // Dispara una bala del cañón
    public void Fire()
    {
        GameObject cannonball = Instantiate(cannonballPrefab, transform.position, transform.rotation);
        Rigidbody cannonballRigidbody = cannonball.GetComponent<Rigidbody>();
        cannonballRigidbody.AddForce(transform.forward * cannonballSpeed, ForceMode.Impulse);
    }
}
