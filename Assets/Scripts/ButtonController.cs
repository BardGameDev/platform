﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public GameObject puzzleObject = null;
	public string id = "-1";
	public int type = -1;
	public float timer = -1;

	private LevelController controller;
	private Renderer rend;
	private bool beenClicked = false;

	void Start(){
		rend = GetComponent<Renderer>();
		controller =  GameObject.FindGameObjectWithTag ("Controller").GetComponent<LevelController>();
	}

	void OnTriggerEnter(Collider Other) {
		if(Other.gameObject.CompareTag("PlayerTrigger")){
			ToggleClicked ();
			if (type == 1) {
				controller.buttonPressed (id, type, beenClicked, gameObject, puzzleObject);	
			} else if (type == 2) {
				controller.buttonCount (id, timer, beenClicked, gameObject, puzzleObject);
			}
		}
	}

	void OnTriggerStay(){
		//type3 send info to level controller
	}

	void OnTriggerExit(){
	//type 3 toggle
	}

	public void ToggleClicked(){
		if (beenClicked) {
			rend.material.color = Color.green;
			beenClicked = false;
		} else {
			rend.material.color = Color.red;
			beenClicked = true;
		}
	}
		
}
