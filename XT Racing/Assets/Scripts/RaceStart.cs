using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceStart : MonoBehaviour
{
    public GameObject countdown;
	public AudioSource counter;
	public AudioSource starter;
	public static bool isRaceOn = false;
    void Start()
    {
		isRaceOn = false;
		if (Application.loadedLevelName != "FirstScene" && Application.loadedLevelName != "Tutorial") {
			StartCoroutine (CountStart());
		}
		else {
			isRaceOn = true;
		}
    }
	
	IEnumerator CountStart() {
		yield return new WaitForSeconds(0.5f);
		countdown.GetComponent<Text>().text = "3";
		counter.Play();
		countdown.SetActive(true);
		yield return new WaitForSeconds(0.8f);
		countdown.SetActive(false);
		yield return new WaitForSeconds(0.2f);
		countdown.GetComponent<Text>().text = "2";
		counter.Play();
		countdown.SetActive(true);
		yield return new WaitForSeconds(0.8f);
		countdown.SetActive(false);
		yield return new WaitForSeconds(0.2f);
		countdown.GetComponent<Text>().text = "1";
		counter.Play();
		countdown.SetActive(true);
		yield return new WaitForSeconds(0.8f);
		countdown.SetActive(false);
		yield return new WaitForSeconds(0.2f);
		countdown.GetComponent<Text>().text = "START";
		starter.Play();
		isRaceOn = true;
		countdown.SetActive(true);
		yield return new WaitForSeconds(0.8f);
		countdown.SetActive(false);
	}
}
