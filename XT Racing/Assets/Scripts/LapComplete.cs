using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LapComplete : MonoBehaviour
{
    public GameObject lapCompleteTrig;
	public GameObject halfLapTrig;
	public GameObject checkSpawn;
	public GameObject checkDeac;
	
	public GameObject LapNumber;
	public GameObject FinishText;
	public GameObject PostRace;
	public GameObject Check;
	public GameObject FinalTime;
	public static int LapCount;
	public AudioSource Finish;
	public AudioSource WorldBGM;
	private int FalseStart = 1;
	public static bool isRaceComplete = false;
	public GameObject light3;
	
	void OnTriggerEnter()
    {
		LapCount += 1;
		if (LapCount < 4) {
			if(LapCount == 2) {
				StartCoroutine (Lap2());
			}
			
			if (LapCount == 3) {
				StartCoroutine (Lap3());
			}	
			
			LapNumber.GetComponent<Text>().text = "" + LapCount + "/3";
			halfLapTrig.SetActive(true);
			checkSpawn.SetActive(true);
			checkDeac.SetActive(false);
		}
		if (LapCount > 3) {
			if (isRaceComplete == false) {
				StartCoroutine (RaceFinish());
				isRaceComplete = true;
			}
		}
		LapTimeManager.SecondCount = 0;
		if (FalseStart == 1 && LapCount < 2) {
			LapTimeManager.SecondCount = 30;
			LapTimeManager.SecondCount2 += 30;
			light3.GetComponent<Light>().enabled = true;
		}
		LapTimeManager.MinuteCount = 0;
		LapTimeManager.deciCount = 0;
    }
	
    void Start()
    {
        LapCount = 0;
		LapTimeManager.SecondCount = 0;
		LapTimeManager.MinuteCount = 0;
		LapTimeManager.deciCount = 0;
		isRaceComplete = false;
		StartCoroutine (CountStart());
    }
	
	void Update() {
		
	}

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(3.5f);
		FalseStart = 0;
    }
	
	IEnumerator RaceFinish()
	{
		FinishText.GetComponent<Text>().text = "FINISH";
		FinalTime.GetComponent<Text>().text = "Final Time: " + LapTimeManager.MinuteCount2 + ":" + LapTimeManager.SecondCount2 + "." + LapTimeManager.deciCount2;
		Finish.Play();
		WorldBGM.Stop();
		FinishText.SetActive(true);
		yield return new WaitForSeconds(10);
		PostRace.SetActive(true);
	}
	
	IEnumerator Lap2()
	{
		Check.GetComponent<Text>().text = "2 Laps to Go";
		Check.SetActive(true);
		yield return new WaitForSeconds(3f);
		Check.SetActive(false);
		lapCompleteTrig.SetActive(false);
	}
	
	IEnumerator Lap3()
	{
		Check.GetComponent<Text>().text = "Final Lap!";
		Check.SetActive(true);
		yield return new WaitForSeconds(3f);
		Check.SetActive(false);
		lapCompleteTrig.SetActive(false);
	}
}
