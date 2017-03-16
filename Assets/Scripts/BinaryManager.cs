using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryManager : MonoBehaviour {

	bool[] puzzle = new bool[6];
	bool [] ans = new bool[6];
	public GameObject PickUp;

	private int count;
	private bool isDone;

	void Start(){
		PickUp.SetActive (false);

		for (int i = 0; i < puzzle.Length; i++) {
			puzzle [i] = false;
			ans [i] = false;
		}
		ans [0] = true;
		ans [3] = true;
		ans [4] = true;
		isDone = false;
	}

	void binary1(){
		puzzle [0] = puzzle [0] == false;
	}
	void binary2(){
		puzzle [1] = puzzle [1] == false;
	}
	void binary4(){
		puzzle [2] = puzzle [2] == false;
	}
	void binary8(){
		puzzle [3] = puzzle [3] == false;
	}
	void binary16(){
		puzzle [4] = puzzle [4] == false;
	}
	void binary32(){
		puzzle [5] = puzzle [5] == false;
	}

	void Update(){
		if(!isDone){
		 	count = 0;
			for (int i = 0; i < puzzle.Length; i++) {
				if (puzzle [i] == ans [i]) {
					count++;
				}
			}
		}
		if (count == 6) {
			//bring down platform
			//activate pickup object
			PickUp.SetActive(true);
			isDone = true;
			Vector3 final_pos = new Vector3(gameObject.transform.position.x, -11.5f,gameObject.transform.position.z);
			gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, final_pos, Time.deltaTime);
		}
	}
}
