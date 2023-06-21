using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(InputController))]
public class ShootController
{
    private InputController _inputController;
    private GameObject _bulletPrefab;
    private Transform _spawnPoint;

    [SerializeField] private float _spawnRate = 0.1f;
    [SerializeField] private float _reloadTime = 2f;
    private float _timeSinceLastSpawn = 0f;
    [SerializeField] private int _ammoCount = 10;
    private int _minAmmo = 3;

    public ShootController(InputController ic, GameObject bp, Transform sp)
    {
        _inputController = ic;
        _bulletPrefab = bp;
        _spawnPoint = sp;
    }

    public void ArtificialLateUpdate()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        if (_inputController.isShooting && _timeSinceLastSpawn >= _spawnRate && _ammoCount > 0)
        {
            GameObject instancedObj = GameObject.Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation) as GameObject;

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
