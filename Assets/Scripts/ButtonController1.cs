using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController1 : MonoBehaviour {

	public GameObject pad;
	private bool beenClicked = false;
	private Renderer rend;

	void Start() {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
	}

// Button contoller specifically for Elias

	void OnTriggerEnter(Collider Other) {
		if(Other.gameObject.CompareTag("PlayerTrigger") && !beenClicked){
			pad.transform.Translate(new Vector3(0,1.4f, 0));
			beenClicked = true;
			rend.material.color = Color.red;

		}
	}

	void OnTriggerStay(Collider Other) {}
	void OnTriggerExit(Collider Other) {}

}
