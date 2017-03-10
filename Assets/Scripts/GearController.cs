using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour {
	private float direction = 1;
	public bool buttonPressed;

	void pressedButton(){
		buttonPressed = true;
	}

	void counterClockwise(){
		transform.Rotate(new Vector3 (0, 10,  0) * Time.deltaTime);
	}

	void clockwise(){
		transform.Rotate(new Vector3 (0, -10,  0) * Time.deltaTime);
	}

	void FixedUpdate () {
		if (buttonPressed) {
			foreach (Transform child in transform) {
				child.Rotate (new Vector3 (0, 0, 50) * Time.deltaTime * direction);
				direction *= -1;
			}
		}
	}
}