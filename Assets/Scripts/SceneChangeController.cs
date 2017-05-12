using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeController : MonoBehaviour {
	private LevelController controller;
	private Scene outside_scene;

	void Start(){
		outside_scene = SceneManager.GetSceneByName ("ClockOutside");
		controller = GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController> ();
	}

	void OnTriggerEnter(Collider Other){
		if (Other.gameObject.CompareTag ("PlayerTrigger")) {
			if (SceneManager.GetActiveScene() == outside_scene) {
				if (!controller.isClockFixed) {
					SceneManager.LoadScene ("ClockInside", LoadSceneMode.Single);
				}
			} else {
				if (controller.isClockFixed) {
					controller.deactivateLerp ();
					SceneManager.LoadScene ("ClockOutside", LoadSceneMode.Single);
				}
			}
		}
	}
}
