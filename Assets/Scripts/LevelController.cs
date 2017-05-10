using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public static LevelController me;

	private ButtonController curr_button_script;
	private GameObject curr_button_puzzle;
	private GameObject curr_dropoff;

	private string pickedUpName = ""; 
	private GameObject pickedUpObj;

	private string timerID; // which timer is currently active or was last active
	private bool startTimer; // is there a timer active
	private float timeLeft; // time left on active timer


	void Awake(){
		//Makes LevelController a singleton
		if (me == null) {
			me = this;
			DontDestroyOnLoad (gameObject);
		} else if (me != this) {
			Destroy (gameObject);
		}

	}
		
// LEVEL SPECIFIC FROM HERE ON OUT

	private bool isClockFixed;

	private bool activateLerp;
	private float startTimeLerp;
	private float distLerp;
	private Vector3 finalPos;

	void Start(){
		isClockFixed = false;
		activateLerp = false;
		finalPos = new Vector3 (0.34f, -4.39f, 18f);
	}

	public void clockFixed(){
		isClockFixed = true;
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

	void FixedUpdate(){
		if (activateLerp) {
			float distCovered = (Time.time - startTimeLerp);
			float fracJourney = distCovered / distLerp;
			curr_dropoff.transform.position = Vector3.Lerp (curr_dropoff.transform.position, finalPos, fracJourney);
		}
	}
		
	public void dropTrigger(string id, GameObject missingChild){
		//check if drop trigger id equates to pickedUpName, if so, put object in place by activating missingChild
	}
	public void dropLerp(GameObject missing){
		startTimeLerp = Time.time;
		distLerp = Vector3.Distance(missing.transform.position, finalPos);
		curr_dropoff = missing;
		activateLerp = true;
		//Lerp that bitch into place
		isClockFixed = true;
	}
	//Called by PickUpController
	public void pickUpObject(string id, GameObject pickUp){
		//set local id to global pickedUpName variable
		//set local pickUp obj to global pickedUpObj variable.
		
	}

	//Called by ButtonController
	public void buttonPressed(string id, bool beenClicked, GameObject button, GameObject puzzle){

	}

	public void buttonActivate(string id, GameObject puzzle){
		print (id);
		if(id.Equals("platButton")){
			puzzle.GetComponent<MovingPatformController> ().toggleActive ();
		}
	}

	public void buttonDeactivate(string id, GameObject puzzle){
		print (id);
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
	public void cPadUsed(GameObject self, string id, string direction, GameObject puzzle){
		if (isClockFixed) {			
			if (id.Equals ("clock")) {
				if(direction.Equals("counterClockwise")){
					puzzle.transform.Rotate (Vector3.right);
				}else{
					puzzle.transform.Rotate (Vector3.left);
				}
			}
		}
	}
		
}
