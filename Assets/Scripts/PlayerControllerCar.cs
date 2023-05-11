using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCar : MonoBehaviour
{
    [Range (0f , 27.69f), SerializeField, Tooltip ("Velocidad actual")] 
    public float speed;

    [Range(0f, 45f), SerializeField, Tooltip("Velocidad velocidad de rotacion")]
    public float speedrotation;

    float HorizontalInPut, VerticalInPut;



    void Update()
    {
        HorizontalInPut = Input.GetAxis("Horizontal");

        transform.Rotate(speed * Time.deltaTime * Vector3.up * VerticalInPut);
        transform.Translate(speed*Time.deltaTime*Vector3.forward *HorizontalInPut);
    }
}
