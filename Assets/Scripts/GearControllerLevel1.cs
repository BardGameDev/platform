using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearControllerLevel1 : MonoBehaviour {
	private float direction = 1;
	public bool buttonPressed;
	private bool pickUpGearFound;
	private GameObject pickUp;
	private PickUp pickUpScript;
	private Transform[] gearChildren = new Transform[3];

	private bool done;

	void Start(){
		pickUp = GameObject.FindGameObjectWithTag("GearPickUp");
		pickUpScript = pickUp.GetComponent<PickUp> ();
		pickUpGearFound = false;

		done = false;

		int i = 0;
		foreach (Transform child in transform) {
			gearChildren[i] = child;
			i++;
		}
	}
	public bool isDone(){
		return done;
	}
	void pressedButton(){
		buttonPressed = true;
	}

	void counterClockwise(){
		if (pickUpGearFound) {
			gearChildren[0].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
			gearChildren[1].Rotate(new Vector3 (0, 0, 50) * Time.deltaTime * direction);
			gearChildren[2].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
		} else {
			gearChildren[0].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
		}
	}

	void clockwise(){
		if (pickUpGearFound) {
			gearChildren[0].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
			gearChildren[1].Rotate(new Vector3 (0, 0, 50) * Time.deltaTime * direction);
			gearChildren[2].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
		} else {
			gearChildren[0].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
		}
	}

	void FixedUpdate () {
		if (buttonPressed) {
			gearChildren[0].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
			gearChildren[1].Rotate(new Vector3 (0, 0, 50) * Time.deltaTime * direction);
			gearChildren[2].Rotate(new Vector3 (0, 0, -50) * Time.deltaTime * direction);
		}
	}

	void OnTriggerEnter(Collider Other){
		if (Other.gameObject.CompareTag("PlayerTrigger")&& pickUpScript.isAttached){
			Debug.Log ("wowzah!");
			pickUp.SendMessage ("off");
			done = true;
			gearChildren[1].gameObject.SetActive (true);
		}
	}
}