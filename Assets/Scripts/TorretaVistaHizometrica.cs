using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaVistaHizometrica : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 5;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    public GameObject Proyectil;
    public Transform ShotPoint;



    //public GameObject Explosion;
    private void Update()
    {
        float HorizontalRotation = Input.GetAxis("Mouse X");
        float VericalRotation = Input.GetAxis("Mouse Y");
        Cursor.lockState = CursorLockMode.Locked;


        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles +
            new Vector3( HorizontalRotation * rotationSpeed, 0));

        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject proyectil = Instantiate(Proyectil, ShotPoint.position, ShotPoint.rotation);
            proyectil.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;

            //Added explosion for added effect
            //Destroy(Instantiate(Explosion, ShotPoint.position, ShotPoint.rotation), 2);

            //Shake the screen for added effect
            //Screenshake.ShakeAmount = 5;

        }
    }
}
