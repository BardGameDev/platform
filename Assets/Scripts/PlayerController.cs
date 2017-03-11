﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody playerRB;
	private Vector3 gravDown;
	public GameObject player;
	public Transform camera;

	public GameObject cubePrefab;

	private float offsetX;
	private float offsetZ;
	public float speed;
	public float jumpSpeed;

	private bool inAir;
	private bool PowerUpDoubleJump;

	void Start(){

		playerRB = GetComponent<Rigidbody> ();

		gravDown = new Vector3(0, -25, 0);

		Physics.gravity = gravDown; //Set the world gravity to 25 - felt realistic
	}

	void FixedUpdate(){

		Debug.LogWarning (playerRB.velocity.z);
		/* Adding both torque and force at the same time
		 gives you good control at lower speed but still
		 leaves the ability to accelerate */

		float moveHor = Input.GetAxis ("Horizontal");  
 		float moveVer = Input.GetAxis ("Vertical");

		offsetX = (transform.position.x - camera.position.x)/4;
		offsetZ = (transform.position.z - camera.position.z)/4;

		// Getting the offset from the X and Z allows us to always move the ball in relation to the camera
		
		Vector3 forceMovement = new Vector3 (moveHor*offsetZ + moveVer*offsetX, 0.0f, moveVer*offsetZ - moveHor*offsetX);
		// Because torque is weird the axes are flipped for the torque movement vector		
		Vector3 torqueMovement = new Vector3 (moveVer*offsetZ - moveHor*offsetX, 0.0f, -moveHor*offsetZ - moveVer*offsetX);
		
		Vector3 jump = new Vector3 (0.0f, jumpSpeed, 0.0f);

		playerRB.AddTorque (torqueMovement * (speed * 2));
		// I felt like giving a higher precedence to torque but I actually dont know if this does anything
		// The following if statement ensures that the ball does not continue to accelerate indefinitely
		if (playerRB.velocity.x < speed && playerRB.velocity.z < speed && playerRB.velocity.x > -speed && playerRB.velocity.z > -speed)
		{
			playerRB.AddForce(forceMovement * (speed * 2 / 3));
		}

		if (Input.GetKeyDown (KeyCode.Space)) { 
			if (!inAir) {
				playerRB.AddForce (jump); //This code is useful if you want to implement double jump so I'll just leave it
			}
		}

		//Kirby's Down B
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if (!cubePrefab.activeSelf)
			{
				cubePrefab.SetActive(true);
			}
			else if (cubePrefab.activeSelf)
			{
				cubePrefab.SetActive(false);
			}
		}
	}

	void OnTriggerEnter(Collider Other) {
		if (Other.gameObject.CompareTag("Jumpable")){
			// This was the best way I found for specifying where you can jump
			// In order to implement this you need to have a mesh collider that
			// covers the surface of the area you want to let the player jump on
			// The tag can also just be placed on all ground objects

			inAir = false; 
		}

		//Both of these compareTags are in the player controller script because they regard the deactivation of gameObjects

		//find all the switches, and the door opens (if there are any switches at all)
		if (Other.gameObject.CompareTag("Switch"))
		{
			Other.gameObject.SetActive(false);
			SwitchManager.switchCount++;
			Debug.LogWarning(SwitchManager.switchCount);
			//FROM THE TUTORIAL: score++;
			//FROM THE TUTORIAL: scoreText.text = "Score: " + score;
		}

		//the bouncy pills

		if (Other.gameObject.CompareTag("Bounce"))
		{
			Other.gameObject.SetActive(false);
			playerRB.velocity = new Vector3(playerRB.velocity.x, playerRB.velocity.y + jumpSpeed/50, playerRB.velocity.z);
		}

	}

	void OnTriggerStay(Collider Other) {
		if (Other.gameObject.CompareTag("Jumpable")){
			inAir = false;
		}

	}

	void OnTriggerExit(Collider Other) {
		inAir = true; // Whenever you leave a trigger its probably because you're in the air.
	}
}
