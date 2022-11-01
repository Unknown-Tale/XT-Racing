using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Rigidbody target;
    public float maxSpeed = 250.0f;
	public Text speedLabel;
	public float speed = 0.0f;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = target.velocity.magnitude * 3.6f;
		if (speedLabel != null) {
            speedLabel.text = ((int)speed) + " km/h";
			}
    }
}
