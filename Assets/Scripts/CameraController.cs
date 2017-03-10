using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform player;
	private Vector3 lookUp;
	private Vector3 offset;

	public float turnSpeed;

	void Start () {
		offset = transform.position - player.transform.position;
		lookUp = Vector3.up * 2;
	}

	void LateUpdate()
	{
		offset = Quaternion.AngleAxis (Input.GetAxis ("Mouse X") * turnSpeed, lookUp) * offset;

		transform.position = player.position + offset;
		transform.LookAt (player.position + lookUp);
	}
}
