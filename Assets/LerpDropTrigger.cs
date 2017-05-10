using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDropTrigger : MonoBehaviour {

	private LevelController controller;
	public GameObject missing;

	void Start(){
		controller = GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController> ();
	}


	void OnTriggerEnter(Collider other){
		if (other.CompareTag("GearPickUp")){
			controller.dropLerp (missing);
		}			
	}
}
