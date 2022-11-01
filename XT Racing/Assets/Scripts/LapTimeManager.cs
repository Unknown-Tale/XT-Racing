using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    
    public static int MinuteCount;
	public static int SecondCount;
	public static float deciCount;
	public static string dDisplay;
	
	public GameObject MinuteBox;
	public GameObject SecondBox;
	public GameObject deciBox;
	
	public static int MinuteCount2;
	public static int SecondCount2;
	public static float deciCount2;
	public static string dDisplay2;
	
	public GameObject MinuteBox2;
	public GameObject SecondBox2;
	public GameObject deciBox2;

    
    void Start()
	{
		deciCount = 0;
		SecondCount = 0;
		MinuteCount = 0;
		deciCount2 = 0;
		SecondCount2 = 0;
		MinuteCount2 = 0;
	}
	
	void Update()
    {
		if (LapComplete.LapCount > 0 && LapComplete.LapCount < 4) {
			deciCount += Time.deltaTime * 100;
			deciCount2 += Time.deltaTime * 100;
			dDisplay = deciCount.ToString("f0");
			dDisplay2 = deciCount2.ToString("f0");
			
			if (deciCount <= 9) {
				deciBox.GetComponent<Text>().text = "0" + dDisplay;
			}
			if (deciCount > 9) {
				deciBox.GetComponent<Text>().text = "" + dDisplay;
			}
			if (deciCount >= 100) {
				deciBox.GetComponent<Text>().text = "00";
			}
			if (deciCount >= 100) {
				SecondCount += 1;
				deciCount = 0;
			}
			
			if (deciCount2 <= 9) {
				deciBox2.GetComponent<Text>().text = "0" + dDisplay2;
			}
			if (deciCount2 > 9) {
				deciBox2.GetComponent<Text>().text = "" + dDisplay2;
			}
			if (deciCount2 >= 100) {
				deciBox2.GetComponent<Text>().text = "00";
			}
			if (deciCount2 >= 100) {
				SecondCount2 += 1;
				deciCount2 = 0;
			}
			
			if (SecondCount <= 9) {
				SecondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
			} else {
				SecondBox.GetComponent<Text>().text = "" + SecondCount + ".";
			}
			if (SecondCount >= 60) {
				SecondCount = 0;
				MinuteCount += 1;
			}
			if (MinuteCount <= 9) {
				MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
			} else {
				MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
			}
			
			if (SecondCount2 <= 9) {
				SecondBox2.GetComponent<Text>().text = "0" + SecondCount2 + ".";
			} else {
				SecondBox2.GetComponent<Text>().text = "" + SecondCount2 + ".";
			}
			if (SecondCount2 >= 60) {
				SecondCount2 = 0;
				MinuteCount2 += 1;
			}
			if (MinuteCount2 <= 9) {
				MinuteBox2.GetComponent<Text>().text = "0" + MinuteCount2 + ":";
			} else {
				MinuteBox2.GetComponent<Text>().text = "" + MinuteCount2 + ":";
			}
		}
    }
}
