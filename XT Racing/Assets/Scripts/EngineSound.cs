using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    AudioSource audioSource;
	public float minPitch = 0.05f;
	private float pitchFromCar;
	
	// Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
		audioSource.pitch = minPitch;
    }

    // Update is called once per frame
    void Update()
    {
        pitchFromCar = PlayerControllerV2.cc.currentSpeed;
		if(pitchFromCar < minPitch)
            audioSource.pitch = minPitch;
        else
            audioSource.pitch = pitchFromCar;
		
		if(PauseMenu.isGamePaused == true)
			audioSource.Pause();
		else {
			if(audioSource.isPlaying)
				return;
			audioSource.Play();
		}
    }
}
