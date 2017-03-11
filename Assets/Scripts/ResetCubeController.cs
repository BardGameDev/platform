using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCubeController : MonoBehaviour {
	public GameObject player;

	private Rigidbody playerRB;
	private Vector3 startpos;

	//array for double jumping

	private GameObject[] bouncePills;

	void Start() {
		startpos = player.transform.position;
		playerRB = player.GetComponent<Rigidbody> ();

		//reference to aray for double jumping

		bouncePills = GameObject.FindGameObjectsWithTag ("Bounce");
	}

	void OnTriggerEnter(Collider Other) {}

	void OnTriggerStay(Collider Other){}

	void OnTriggerExit(Collider Other){
		if (Other.gameObject.CompareTag("Player")) {
			playerRB.velocity = Vector3.zero;
			playerRB.angularVelocity = Vector3.zero;
			player.transform.position = startpos;

			//for loop is for resetting powerups.  While two for loops in a row is gross (this plus the switch manager), we're not going to be calling this, a lot.

			for (int x = 0; x < bouncePills.Length; x++) {
				if (!bouncePills[x].activeSelf) {
					bouncePills[x].SetActive (true);
				}
			}

			SwitchManager.Reset();
		}
	}
}
