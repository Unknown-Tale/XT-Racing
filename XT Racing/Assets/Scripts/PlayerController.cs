using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private const string HORIZONTAL = "Horizontal";
	private const string VERTICAL = "Vertical";
	
	private float horizontalInput;
	private float verticalInput;
	private float currentSteerAngle;
	
	[SerializeField] private float motorForce;
	[SerializeField] private float maxSteerAngle;
	
	[SerializeField] private WheelCollider Wheel1L;
	[SerializeField] private WheelCollider Wheel1R;
	[SerializeField] private WheelCollider Wheel2L;
	[SerializeField] private WheelCollider Wheel2R;
	
	[SerializeField] private Transform Disk_1L;
	[SerializeField] private Transform Disk_1R;
	[SerializeField] private Transform Disk_2L;
	[SerializeField] private Transform Disk_2R;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		GetInput();
		HandleMotor();
		HandleSteering();
		UpdateWheels();
    }
	
	void GetInput()
	{
		horizontalInput = Input.GetAxis(HORIZONTAL);
		verticalInput = Input.GetAxis(VERTICAL);
	}
	
	void HandleMotor()
	{
		Wheel1L.motorTorque = verticalInput * motorForce;
		Wheel1R.motorTorque = verticalInput * motorForce;
		if (verticalInput > 0 && motorForce < 0) {
			Wheel1L.motorTorque = verticalInput * motorForce;
			Wheel1R.motorTorque = verticalInput * motorForce;
		}
		if (verticalInput < 0 && motorForce > 0) {
			Wheel1L.motorTorque = verticalInput * motorForce;
			Wheel1R.motorTorque = verticalInput * motorForce;
		}
	}
	
	void HandleSteering()
	{
		currentSteerAngle = maxSteerAngle * horizontalInput;
		Wheel1L.steerAngle = currentSteerAngle;
		Wheel1R.steerAngle = currentSteerAngle;
	}
	
	void UpdateWheels()
	{
		UpdateSingleWheel(Wheel1L, Disk_1L);
		UpdateSingleWheel(Wheel1R, Disk_1R);
		UpdateSingleWheel(Wheel2L, Disk_2L);
		UpdateSingleWheel(Wheel2R, Disk_2R);
	}
	
	void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
	{
		Vector3 pos;
		Quaternion rot;
		wheelCollider.GetWorldPose(out pos, out rot);
		wheelTransform.rotation = rot;
		wheelTransform.position = pos;
	}
}
