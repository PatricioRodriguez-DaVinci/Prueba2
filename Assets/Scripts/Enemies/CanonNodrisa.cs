using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonNodrisa : MonoBehaviour
{
    public GameObject cannonballPrefab; // Prefab de la bala del ca��n
    public float timeBetweenShots = 5f; // Tiempo entre cada disparo
    public float cannonballSpeed = 10f; // Velocidad de la bala del ca��n
    private float timeSinceLastShot; // Tiempo transcurrido desde el �ltimo disparo

    void Start()
    {
        timeSinceLastShot = timeBetweenShots; // Inicializa el tiempo transcurrido desde el �ltimo disparo
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime; // Incrementa el tiempo transcurrido desde el �ltimo disparo
        if (timeSinceLastShot >= timeBetweenShots)
        {
            // Si ha pasado el tiempo suficiente desde el �ltimo disparo, dispara una bala del ca��n
            Fire();
            timeSinceLastShot = 0f; // Reinicia el tiempo transcurrido desde el �ltimo disparo
        }
    }

    // Dispara una bala del ca��n
    public void Fire()
    {
        GameObject cannonball = Instantiate(cannonballPrefab, transform.position, transform.rotation);
        Rigidbody cannonballRigidbody = cannonball.GetComponent<Rigidbody>();
        cannonballRigidbody.AddForce(transform.forward * cannonballSpeed, ForceMode.Impulse);
    }
}
