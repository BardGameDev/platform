using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPatformController : MonoBehaviour {

	public bool goingLeft;
	public int speed;
	public bool active;
	public float distance;

	private float startPos_x;

	// Use this for initialization
	void Start () {
		if (goingLeft) {
			startPos_x = transform.position.x - 5;
		} else {
			startPos_x = transform.position.x + 5;
		}

	}

	public void toggleActive(){
		active = !active;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (active) {
			if (Mathf.Abs (startPos_x - gameObject.transform.position.x) > distance/2) {
				goingLeft = !goingLeft;
			}
			if (goingLeft) {
				gameObject.transform.Translate (Vector3.right * -speed * Time.deltaTime);
			} else { //is right
				gameObject.transform.Translate (Vector3.right * speed * Time.deltaTime);
			}
		}
	}
}
