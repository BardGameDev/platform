using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrbController : MonoBehaviour {
	public float pullRadius;
	public float pullForce;
	public float speed;
	public GameObject player;

	private Rigidbody playerRB;
	private Vector3 startpos;

	void Start() {
		startpos = player.transform.position;
		playerRB = player.GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		Rotate ();

		foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius)) {
			if (collider.gameObject.CompareTag("Player")) {
				
				// Calculate vector towards gravOrb
				Vector3 forceDirection = transform.position - player.transform.position;

				// apply force on player towards gravOrb
				playerRB.AddForce (forceDirection.normalized * pullForce * Time.fixedDeltaTime);
			}
		}
	}

	void Rotate(){
		transform.Rotate (new Vector3 (30, 10, 50) * Time.deltaTime * speed);
		foreach (Transform child in transform) {
				child.Rotate (new Vector3 (30, 10, 50) * Time.deltaTime * speed);
		}
	}

	void OnTriggerEnter(Collider Other) {
		if (Other.gameObject.CompareTag("Player")) {
			playerRB.velocity = Vector3.zero;
			playerRB.angularVelocity = Vector3.zero;
			player.transform.position = startpos;
		}
	}
	void OnTriggerStay(Collider Other){}

	void OnTriggerExit(Collider Other){}
}
