using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterweightController : MonoBehaviour {
	
	public GameObject finalObject;
	private bool pickUpWeightFound;
	public GameObject pickUp;
	private PickUp pickUpScript;

	private bool done;

	void Start(){
		pickUpScript = pickUp.GetComponent<PickUp> ();
		finalObject.SetActive (false);
		done = false;
	}

	public bool isDone(){
		return done;
	}

	void OnTriggerEnter(Collider Other){
		if (Other.gameObject.CompareTag("PlayerTrigger") && pickUpScript.isAttached){
			finalObject.SetActive (true);
			done = true;
			pickUp.SendMessage ("off");

		}
	}
}