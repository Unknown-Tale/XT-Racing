using UnityEngine;
using System.Collections;
public class PlayerControllerV2 : MonoBehaviour {
    public static PlayerControllerV2 cc;
	public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelRL;
    public WheelCollider WheelRR;
    public Transform WheelFLtrans;
    public Transform WheelFRtrans;
    public Transform WheelRLtrans;
    public Transform WheelRRtrans;
    public Vector3 eulertest;
	public GameObject light1;
	public GameObject light2;
	public GameObject light3;
	public GameObject light4;
	GameObject respawnPoint;
    float maxFwdSpeed = 69;
    float maxBwdSpeed = -25f;
	public float currentSpeed;
	float currentSpeed2;
    float gravity = 9.8f;
    private bool braked = false;
	private bool lights = false;
    private float maxBrakeTorque = 1000;
    private Rigidbody rb;
    public Transform centreofmass;
    private float maxTorque = 2000;
	
    void Start () 
    {
        cc = this;
		rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreofmass.transform.localPosition;
    }
    
	void FixedUpdate () {
		if (RaceStart.isRaceOn == true)
		{
			currentSpeed = rb.velocity.magnitude / 12;
			currentSpeed2 = rb.velocity.magnitude;
			
			if (currentSpeed2 > maxFwdSpeed)
			{
				maxTorque = 0;
			}
			else
			{
				maxTorque = 2000;
			}
			
     		if(!braked){
            	WheelFL.brakeTorque = 0;
            	WheelFR.brakeTorque = 0;
            	WheelRL.brakeTorque = 0;
            	WheelRR.brakeTorque = 0;
        	}
        	//speed of car, Car will move as you will provide the input to it.
   			
      		WheelRR.motorTorque = maxTorque * Input.GetAxis("Vertical");
        	WheelRL.motorTorque = maxTorque * Input.GetAxis("Vertical");
      		
        	//changing car direction
        	WheelFL.steerAngle = 35 * (Input.GetAxis("Horizontal"));
        	WheelFR.steerAngle = 35 * Input.GetAxis("Horizontal");
		}
    }
    void Update()
    {
        if (RaceStart.isRaceOn == true)
		{
			HandBrake();
			Headlight();
			Respawn();
        	
        	//for tyre rotate
        	WheelFLtrans.Rotate(WheelFL.rpm/60*360*Time.deltaTime ,0,0);
        	WheelFRtrans.Rotate(WheelFR.rpm/60*360*Time.deltaTime ,0,0);
        	WheelRLtrans.Rotate(WheelRL.rpm/60*360*Time.deltaTime ,0,0);
        	WheelRRtrans.Rotate(WheelRL.rpm/60*360*Time.deltaTime ,0,0);
        	//changing tyre direction
        	Vector3 temp = WheelFLtrans.localEulerAngles;
        	Vector3 temp1 = WheelFRtrans.localEulerAngles;
        	temp.y = WheelFL.steerAngle - (WheelFLtrans.localEulerAngles.z);
        	WheelFLtrans.localEulerAngles = temp;
        	temp1.y = WheelFR.steerAngle - WheelFRtrans.localEulerAngles.z;
        	WheelFRtrans.localEulerAngles = temp1;
        	eulertest = WheelFLtrans.localEulerAngles;
		}
    }
    void HandBrake()
    {
        //Debug.Log("brakes " + braked);
        if(Input.GetButton("Jump"))
        {
            braked = true;
			light1.GetComponent<Light>().enabled = true;
			light2.GetComponent<Light>().enabled = true;
        }
        else
        {
            braked = false;
			light1.GetComponent<Light>().enabled = false;
			light2.GetComponent<Light>().enabled = false;
        }
        if(braked){
         
            WheelRL.brakeTorque = maxBrakeTorque * 20;//0000;
            WheelRR.brakeTorque = maxBrakeTorque * 20;//0000;
            WheelRL.motorTorque = 0;
            WheelRR.motorTorque = 0;
        }
    }
	void Headlight()
	{
		if(Input.GetButton("Fire1"))
        {
			lights = true;
        }
		if(Input.GetButton("Fire2"))
        {
			lights = false;
        }
		if (lights == true)
		{
			light3.GetComponent<Light>().enabled = true;
			light4.GetComponent<Light>().enabled = true;
		}
		else
		{
			light3.GetComponent<Light>().enabled = false;
			light4.GetComponent<Light>().enabled = false;
		}
	}
	
	void Respawn()
	{
		if(Input.GetKeyDown("joystick button 6"))
		{
			respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
			transform.position = respawnPoint.transform.position;
			rb.velocity = Vector3.zero;
			transform.rotation = respawnPoint.transform.rotation;
		}
	}
}