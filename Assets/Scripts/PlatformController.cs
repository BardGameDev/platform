using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
	private bool buttonPressed = false;
	private Vector3 movement;
	private float backLimit = 8.0f;
	private float frontLimit = 4.0f;
	private float direction;

	public float platformSpeed;

	void pressedButton(){
		buttonPressed = true;		
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (buttonPressed) {
			if (transform.position.z > backLimit) {
				direction = -1;
			} else if (transform.position.z < frontLimit) {
				direction = 1;
			}
			movement = Vector3.forward * direction * platformSpeed * Time.deltaTime; 
			transform.Translate (movement); 
		}
	}
}
