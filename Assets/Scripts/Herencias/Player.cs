using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private InputController _inCon;
    private MovementController _moCon;
    private ShootController _shCon;
    private AnimationController _anCon;
//    private JumpController _juCon;

    protected LifeController lifeController;

    private Animator _animator;
    private Rigidbody _rb;
    private Transform _transform;

    public GameObject bulletPrefab;
    public Transform spawnPoint;

    private void Awake()
    {
 //   _juCon = new JumpController();
    _animator = GetComponent<Animator>();
    lifeController = GetComponent<LifeController>();
    _transform = GetComponent<Transform>();
    _rb = GetComponent<Rigidbody>();
    _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    
    }

    private void Start()
    {
        
        lifeController.SetLife();

        _inCon = new InputController();
    _moCon = new MovementController(_inCon, _rb, _transform);
    _shCon = new ShootController(_inCon, bulletPrefab, spawnPoint);
    _anCon = new AnimationController(_inCon, _animator);
    }
    
    public override void TakeDamage(int dmg)
    {
        lifeController.CheckLife(dmg);
    }

    private void Update()
    {
        _inCon.ArtificialUpdate();
        
    }

    private void LateUpdate()
    {
        _shCon.ArtificialLateUpdate();
    }

    private void FixedUpdate()
    {
        _anCon.ArtificialFixedUpdate();
        _moCon.ArtificialFixedUpdate();
    }
}