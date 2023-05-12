using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarInt : MonoBehaviour
{
    
   
    [SerializeField] private Transform car;

    private void OnTriggerStay (Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.transform.tag == "Car")
            {
               gameObject.SetActive (false);
            }
        }
        
    }

}
