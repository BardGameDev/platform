using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour {

	public GameObject c_trigger;
	public GameObject g_trigger;

	public GameObject chains;

	private CounterweightController c_controller;
	private GearControllerLevel1 g_controller;

	void Start(){
		c_controller = c_trigger.GetComponent<CounterweightController> ();
		g_controller = g_trigger.GetComponent<GearControllerLevel1> ();
	}

	void pressedButton(){
		if (c_controller.isDone () && g_controller.isDone ()) {
			print ("done");
			gameObject.transform.Translate (Vector3.down * 3.5f);
			chains.transform.Translate (Vector3.down * 3.5f);
		} else {
			print ("nope");
		}
	}
}
