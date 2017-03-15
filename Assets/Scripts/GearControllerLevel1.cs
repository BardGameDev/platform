using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearControllerLevel1 : MonoBehaviour {
	private float direction = 1;
	public bool buttonPressed;
	private bool pickUpGearFound;
	private GameObject[] pickUps;
	private Transform[] gearChildren = new Transform[3];

	void Start(){
		pickUps = GameObject.FindGameObjectsWithTag("PickUp");

		pickUpGearFound = false;

		int i = 0;
		foreach (Transform child in transform) {
			gearChildren[i] = child;
			i++;
		}
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
		if (Other.gameObject.CompareTag("PlayerTrigger")){
			Debug.Log ("wowzah!");
			pickUpGearFound = true;
			foreach (GameObject child in pickUps) {
				if (child.name.Equals("gearBig")){
					child.SetActive (false);
				}
			}
			gearChildren[1].gameObject.SetActive (true);
		}
	}
}