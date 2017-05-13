using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetCube : MonoBehaviour {

	GameObject player;
	Vector3 initPos;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		initPos = player.gameObject.transform.position;
	}
	
	void OnTriggerExit(){
		
		player.transform.position = initPos;
		player.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}
}
