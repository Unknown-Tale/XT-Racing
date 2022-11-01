using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginMaxiTT : MonoBehaviour
{
    public GameObject loadText;
    void OnTriggerEnter()
    {
        StartCoroutine(Load());
    }

    
    IEnumerator Load()
    {
        loadText.SetActive(true);
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(1);
    }
}
