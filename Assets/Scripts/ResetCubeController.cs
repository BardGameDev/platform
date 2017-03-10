using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCubeController : MonoBehaviour {
	public GameObject player;

	private Rigidbody playerRB;
	private Vector3 startpos;

	void Start() {
		startpos = player.transform.position;
		playerRB = player.GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider Other) {}

	void OnTriggerStay(Collider Other){}

	void OnTriggerExit(Collider Other){
		if (Other.gameObject.CompareTag("Player")) {
			playerRB.velocity = Vector3.zero;
			playerRB.angularVelocity = Vector3.zero;
			player.transform.position = startpos;
		}
	}
}
