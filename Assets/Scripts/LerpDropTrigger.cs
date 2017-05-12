using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDropTrigger : MonoBehaviour {

	private LevelController controller;
	private Behaviour exit;

	public GameObject missing;
	public Vector3 position;

	void Start(){
		controller = GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController> ();
		exit = (Behaviour)GameObject.FindGameObjectWithTag ("Exit").GetComponent ("Halo");
	}


	void OnTriggerEnter(Collider other){
		if (other.CompareTag("GearPickUp")){
			controller.dropLerp (missing, position, exit);
		}			
	}
}
