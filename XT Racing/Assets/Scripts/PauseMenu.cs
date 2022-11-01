using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
	public GameObject pauseMenu;
	public AudioSource WorldBGM;
	
	public GameObject pauseFirstButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 7"))
		{
			if (LapComplete.isRaceComplete == false) {
				if (isGamePaused)
				{
					ResumeGame();
				}
				else
				{
					PauseGame();
				}
			}
		}
    }
	
	public void ResumeGame()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		isGamePaused = false;
		WorldBGM.Play();
	}
	
	void PauseGame()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		isGamePaused = true;
		WorldBGM.Pause();
		
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(pauseFirstButton);
	}
	
	public void Restart()
	{
		Time.timeScale = 1f;
		isGamePaused = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	public void Quit()
	{
		Time.timeScale = 1f;
		isGamePaused = false;
		SceneManager.LoadScene(0);
	}
	
	public void PermaQuit()
	{
		Application.Quit();
		Debug.Log("Retired");
	}
}
