using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController2 : MonoBehaviour {
	 //Button controller for binary puzzle

	public int id;
	public GameObject puzzleObject;
	private bool beenClicked = false;
	private Color green;
	private Color red;

	public Renderer rend;

	void Start() {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		green = rend.material.color;
		red = Color.red;
	}

	void OnTriggerEnter(Collider Other) {
		if(Other.gameObject.CompareTag("PlayerTrigger")){
			puzzleObject.SendMessage (string.Concat("binary", id.ToString()));
			if (beenClicked) {
				rend.material.color = green;
				beenClicked = false;
			} else {
				rend.material.color = red;
				beenClicked = true;
			}

		}
	}
}
