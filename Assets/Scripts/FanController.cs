using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour {
    private GameObject player;
	private Transform blade;
	private Rigidbody playerRB;
	private bool buttonPressed;


    private float fanForce = 16;

	void pressedButton(){
		buttonPressed = true;
	}

    void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody>();
		blade = transform.GetChild (0).transform;
    }

	void FixedUpdate(){
		if (buttonPressed) {
			blade.Rotate(new Vector3 (0, 0, -90) * Time.deltaTime * 2);
		}
	}

	void OnTriggerEnter(Collider Other) {
		if (Other.gameObject.CompareTag ("PlayerTrigger") && buttonPressed) {
			playerRB.AddForce (transform.up * fanForce);
	
		}
	}

	void OnTriggerStay(Collider Other) {
		if (Other.gameObject.CompareTag ("PlayerTrigger") && buttonPressed) {
			playerRB.AddForce (transform.up * fanForce);

		}
    }

	void OnTriggerExit(Collider Other) {}
}
