using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float smoothing = 0.3f;
	private float rSmoothing = 0.1f;
	public Transform player;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate makes the movement of the camera smoother opposed to Update
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, smoothing);
		transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, rSmoothing);
		transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }
}
