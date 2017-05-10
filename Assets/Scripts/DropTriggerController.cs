using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTriggerController : MonoBehaviour {
	/*<summary>
			 This script is assigned to the dropoff area for pickup objects
	</summary>*/


	public string id = "-1"; // automatically set id to -1, developer must pick a real id
	public GameObject missingChild; // deactivated duplicate of pick up object in correct drop off position

	void Start(){
		missingChild.SetActive (false); // set the missing child to false so player will see that it's missing
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("PlayerTrigger")) { // if the player runs/jumps into the designated area
			/* 	Send the level controller a message with the id of the drop off so
			 	the level controller can check if the player is holding the corret pick up.
			 	If it is correct, do something to the pick/missing child
				(most likely destroy the pickup and set the missing child to active)*/
			GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController> ().dropTrigger (id, missingChild);
		}		
	}
}
