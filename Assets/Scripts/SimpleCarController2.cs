using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController2 : MonoBehaviour {

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        leftFrontW.steerAngle = m_steeringAngle;
        rightFrontW.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        leftFrontW.motorTorque = m_verticalInput * motorForce;
        rightFrontW.motorTorque = m_verticalInput * motorForce;

    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(leftFrontW, leftFrontT);
        UpdateWheelPose(rightFrontW, rightFrontT);
        UpdateWheelPose(leftBackW, leftBackT);
        UpdateWheelPose(rightBackW, rightBackT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        HandBrake();
    }

    // Remmen

    void HandBrake ()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            isbrake = true;
        }
        else
        {
            isbrake = false;
        }

        if (isbrake == true)
        {
            leftBackW.brakeTorque = brakeTorque;
            rightBackW.brakeTorque = brakeTorque;
            leftBackW.motorTorque = 0;
            rightBackW.motorTorque = 0;
        }
        else
        {
            leftBackW.brakeTorque = 0;
            rightBackW.brakeTorque = 0;
        }
    }

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider leftFrontW, rightFrontW;
    public WheelCollider leftBackW, rightBackW;
    public Transform leftFrontT, rightFrontT;
    public Transform leftBackT, rightBackT;
    public float maxSteerAngle = 30;
    public float motorForce = 50;

    public bool isbrake = false;
    public float brakeTorque = 5000f;
}
