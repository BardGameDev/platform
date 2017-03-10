using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPadController : MonoBehaviour {
	public float speedBoost;
	public GameObject player;
	private Rigidbody playerRB;
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

	void Start(){
		playerRB = player.GetComponent<Rigidbody>();
	}

	void OnTriggerEnter(Collider Other) {
		if(Other.gameObject.CompareTag("Player") && buttonPressed){
			playerRB.AddForce(transform.forward * speedBoost, ForceMode.Impulse);
		}
	}

	void OnTriggerStay(Collider Other) {}
	void OnTriggerExit(Collider Other) {}
}
