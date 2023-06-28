using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsController : MonoBehaviour, IDamageable
{
    public BigBomb bigBomb;

    [SerializeField] WheelCollider FrontRight;
    [SerializeField] WheelCollider BackRight;
    [SerializeField] WheelCollider FrontLeft;
    [SerializeField] WheelCollider BackLeft;

    [SerializeField] Transform FrontRightTransform;
    [SerializeField] Transform BackRightTransform;
    [SerializeField] Transform FrontLeftTransform;
    [SerializeField] Transform BackLeftTransform;

    public float Acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTunedAngl = 20f;

    float CurrentAcceleration = 0f;
    float CurrentbreakForce = 0f;
    float CurrtntTurnAngle = 0f;

    private void Start()
    {
        bigBomb.bigBombEvent += TakeDamage; 
    }

    private void FixedUpdate()
    {

        CurrentAcceleration = Acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
            CurrentbreakForce = breakingForce;
        else
            CurrentbreakForce = 0f;

    if(FrontRight != null && BackRight != null && FrontLeft != null && BackLeft)
    {
        FrontRight.motorTorque = CurrentAcceleration;
        FrontLeft.motorTorque = CurrentAcceleration;
        BackRight.motorTorque = CurrentAcceleration;
        BackLeft.motorTorque = CurrentAcceleration;

        FrontRight.brakeTorque = CurrentbreakForce;
        FrontLeft.brakeTorque = CurrentbreakForce;
        BackRight.brakeTorque = CurrentbreakForce;
        BackLeft.brakeTorque = CurrentbreakForce;

        CurrtntTurnAngle = maxTunedAngl * Input.GetAxis("Horizontal");
        FrontRight.steerAngle = CurrtntTurnAngle;
        FrontLeft.steerAngle = CurrtntTurnAngle;

        UpdateWheel(FrontRight, FrontRightTransform);
        UpdateWheel(BackRight, BackRightTransform);
        UpdateWheel(FrontLeft, FrontLeftTransform);
        UpdateWheel(BackLeft, BackLeftTransform);  
    }

    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            TakeDamage(100);
        }
    }

    public void TakeDamage(int dmg)
    {
        if(Acceleration >= 0f)
        {
            Acceleration -= dmg;
        }
        else
        {
            CurrentAcceleration = 0f;
            Destroy(FrontRight);
        }
    }

}
