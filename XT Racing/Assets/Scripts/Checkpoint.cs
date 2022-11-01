using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public GameObject lapCompleteTrig;
	public GameObject halfLapTrig;
	public GameObject checkSpawn;
	public GameObject checkDeac;
	public GameObject check;
    void OnTriggerEnter()
    {
        StartCoroutine (CheckpointNotification());
		lapCompleteTrig.SetActive(true);
		checkSpawn.SetActive(true);
		checkDeac.SetActive(false);
    }
	
	IEnumerator CheckpointNotification()
	{
		check.GetComponent<Text>().text = "Checkpoint";
		check.SetActive(true);
		yield return new WaitForSeconds(3f);
		check.SetActive(false);
		halfLapTrig.SetActive(false);
	}
}
