using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PostRaceMenu : MonoBehaviour
{
    public void Restart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	public void Quit()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}
	
	public void PermaQuit()
	{
		Application.Quit();
		Debug.Log("Retired");
	}
}
