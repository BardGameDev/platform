using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeController : MonoBehaviour {

	void OnTriggerEnter(){
		SceneManager.LoadScene ("ClockInside", LoadSceneMode.Single);
	}
}
