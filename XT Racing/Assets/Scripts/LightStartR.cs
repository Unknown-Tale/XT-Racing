using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStartR : MonoBehaviour
{
    public GameObject light1;
	public GameObject light2;
	// Start is called before the first frame update
    void Start()
    {
        StartCoroutine (CountStart());
    }

    IEnumerator CountStart() {
		yield return new WaitForSeconds(3.5f);
		light1.GetComponent<Light>().enabled = false;
		light2.GetComponent<Light>().enabled = true;
	}
}
