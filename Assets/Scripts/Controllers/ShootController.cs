using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class ShootController : MonoBehaviour
{
    private InputController _inputController;

    public GameObject bulletPrefab;
    public Transform spawnPoint;
    [SerializeField] private float _spawnRate = 0.1f;
    [SerializeField] private float _reloadTime = 2f;
    private float _timeSinceLastSpawn = 0f;
    [SerializeField] private int _ammoCount = 10;
    private int _minAmmo = 3;

    private void Start()
    {
        _inputController = GetComponent<InputController>();
    }

    void LateUpdate()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        if (_inputController.isShooting && _timeSinceLastSpawn >= _spawnRate && _ammoCount > 0)
        {
            Debug.Log("Disparar");
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            _timeSinceLastSpawn = 0f;
            _ammoCount--;
        }

        if (_inputController.isReloading && _ammoCount <= _minAmmo)
        {
            _timeSinceLastSpawn = _reloadTime * -1f;
            _ammoCount = 10;
            _inputController.isReloading = false;
        }
    }
}
