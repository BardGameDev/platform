using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeController : MonoBehaviour {

	void OnTriggerEnter(Collider Other){
		if (Other.gameObject.CompareTag ("PlayerTrigger")) {
			SceneManager.LoadScene ("ClockInside", LoadSceneMode.Single);
		}
	}
}
