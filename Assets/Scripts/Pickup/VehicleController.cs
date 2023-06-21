using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && player.activeSelf == false)
        {
            player.SetActive(true);
        }
    }
}
