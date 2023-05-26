using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaserSpawnPoint : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform spawnPoint;
    public float minTime = 1f;
    public float maxTime = 3f;

    private bool isCameraLooking;

    private void Start()
    {
        isCameraLooking = false;
        spawnPoint = GetComponent<Transform>();
    }

    private void Update()
    {
        if (isCameraLooking && !IsInvoking("SpawnObject"))
        {
            Debug.Log("Spawnear");
            float randomTime = Random.Range(minTime, maxTime);
            Invoke("SpawnObject", randomTime);
        }
    }

    private void OnBecameVisible()
    {
        Debug.Log("Visible");
        isCameraLooking = true;
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Invisible");
        isCameraLooking = false;
        CancelInvoke("SpawnObject");
    }

    private void SpawnObject()
    {
        Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}