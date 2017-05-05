using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	private string pickUpID;

	private ButtonController curr_button_script;
	private GameObject curr_button_puzzle;

	private string timerID;
	private bool startTimer; // is there a timer active
	private float timeLeft;

	void Start(){

	}

	void Update(){
		if (startTimer) {
			timeLeft -= Time.deltaTime;
			print ("timeleft: " + timeLeft.ToString ());
			if (timeLeft < 0) {
				timerDone (timerID);
			}
		}
	}
		
	public void dropTrigger(string id, GameObject missingChild){
		
	}
	//Called by PickUpController
	public void pickUpObject(string id, GameObject pickUp){
		
	}

	//Called by ButtonController
	public void buttonPressed(string id, bool beenClicked, GameObject button, GameObject puzzle){

	}

	public void buttonActivate(string id, GameObject puzzle){
		if(id.Equals("platButton")){
			puzzle.GetComponent<MovingPatformController> ().toggleActive ();
		}
	}

	public void buttonDeactivate(string id, GameObject puzzle){
		if(id.Equals("platButton")){
			puzzle.GetComponent<MovingPatformController> ().toggleActive ();
		}
	}

	public void buttonCount(string id, float timer, bool beenClicked, GameObject button, GameObject puzzle){

		timerID = id;
		timeLeft = timer;
		curr_button_script = button.GetComponent<ButtonController>();
		curr_button_puzzle = puzzle;
		startTimer = beenClicked;

		if(id.Equals("clock_fan")){
			curr_button_puzzle.GetComponent<FanController>().active = beenClicked;
		}
	}

	void timerDone(string id){
		startTimer = false;
		curr_button_script.ToggleClicked ();
		if (id.Equals("clock_fan")){
			curr_button_puzzle.GetComponent<FanController> ().active = false;
		}
	}

	//Called by cPad controller
	public void cPadUsed(string id, string direction, GameObject puzzle){
	}
		
}
