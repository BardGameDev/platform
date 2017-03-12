using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinablePlatformController : MonoBehaviour {
	private float endRotation;
	private float speed;

	public GameObject puzzleObject;

	private Vector3 destEuler = new Vector3(-90,0,0);
	private Vector3 currEuler = new Vector3(-90,0,0);

	private bool puzzleObjectOnPad;
	public bool buttonPressed;

	void Start () {
		endRotation = 90.0f;
		speed = 10.0f;
		transform.eulerAngles = destEuler;
		puzzleObjectOnPad = false;
	}
		
	void FixedUpdate () {
		if (buttonPressed) {
			destEuler.y += endRotation;
			buttonPressed = false;
		}

		currEuler = Vector3.Lerp(currEuler, destEuler, Time.deltaTime * speed);
		transform.eulerAngles = currEuler;
		if (puzzleObjectOnPad) {
			puzzleObject.transform.eulerAngles = currEuler;
		}

	}

	void OnTriggerEnter(Collider Other){
		if (Other.gameObject.Equals(puzzleObject)) {
			puzzleObjectOnPad = true;
		}
	}

	void OnTriggerStay(Collider Other){}

	void OnTriggerExit(Collider Other){
		if (Other.gameObject.Equals(puzzleObject)) {
			puzzleObjectOnPad = false;
		}
	}

	void pressedButton(){
		buttonPressed = true;
	}

	void counterClockwise(){
		transform.Rotate(new Vector3 (0, 10,  0) * Time.deltaTime);
	}

	void clockwise(){
		transform.Rotate(new Vector3 (0, -10,  0) * Time.deltaTime);
	}

}
