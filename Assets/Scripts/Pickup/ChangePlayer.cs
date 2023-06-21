using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public GameObject player;
    public MonoBehaviour vehicleMovementScript;

    private bool isPlayer1Active;

    // Object Parenting
    public GameObject parentObject;
    public GameObject childObject;
    private bool isParent = false;
    private bool canChange = false;
    private Transform originalParent;

    void Start()
    {
        vehicleMovementScript.enabled = false;
        originalParent = childObject.transform.parent;
        isPlayer1Active = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canChange)
        {
            isPlayer1Active = !isPlayer1Active;
            player.SetActive(isPlayer1Active);
            vehicleMovementScript.enabled = !isPlayer1Active;
            ObjectParenting();
        }
    }

    private void ObjectParenting()
    {
            if (isParent)
            {
                // Remove parent-child relationship
                childObject.transform.parent = originalParent;
                isParent = false;
            }
            else
            {
                // Make this object the parent
                childObject.transform.parent = transform;
                isParent = true;
            }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player && other.gameObject.CompareTag("Player"))
        {
            canChange = true;
            Debug.Log("Puede");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player && other.gameObject.CompareTag("Player"))
        {
            canChange = false;
        }
    }
}
