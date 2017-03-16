using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour {

	[SerializeField]
	private float hoverHeight = 1f;

	[SerializeField]
	private float hoverForce = 100f;

	private float proportionalHeight;

	private Ray groundSensorRay;
	private Vector3 appliedHoverForce;
	private Rigidbody ObjectRB;

	public bool buttonPressed;

	//I need to put comments on this

	void Start(){
		ObjectRB = GetComponent<Rigidbody> ();
	}

	void pressedButton(){
		buttonPressed = true;
	}

	void FixedUpdate () {

		if (buttonPressed) {
            if (ObjectRB.isKinematic) //if the isKinematic box is checked...
            {
                ObjectRB.isKinematic = false; //turn it back to normal... if the block is a rigidbody above ground, it can be moved no matter what
            }
			groundSensorRay = new Ray (transform.position, -transform.up);
			RaycastHit hit;

			if (Physics.Raycast (groundSensorRay, out hit, hoverHeight)) {
				proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
				appliedHoverForce = Vector3.up * hoverForce * proportionalHeight;
				ObjectRB.AddForce (appliedHoverForce, ForceMode.Acceleration);
			}
		}
	}
}
