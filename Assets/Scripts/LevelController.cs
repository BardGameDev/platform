using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public static LevelController me;

	private ButtonController curr_button_script;
	private GameObject curr_button_puzzle;
	private GameObject curr_dropoff;

	//private string pickedUpName = ""; 
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

	public bool isClockFixed;
	public bool activateLerp;
	public bool rotateFin;

	private float startTimeLerp;
	private float distLerp;
	private Vector3 finalPos;

	private bool hourHand;
	private bool minHand;
	private GameObject[] clockParts = new GameObject[3];
	private GameObject[] FIN = new GameObject[3];
	private GameObject FINDAD;

	void Start(){
		isClockFixed = false;
		activateLerp = false;
		rotateFin = false;
		hourHand = false;
		minHand = false;

		clockParts = GameObject.FindGameObjectsWithTag ("Clock");
		FIN = GameObject.FindGameObjectsWithTag ("Finish");
		FINDAD = GameObject.FindGameObjectWithTag ("FINDAD");
	}

	public void finishGame(){
		clockParts = GameObject.FindGameObjectsWithTag ("Clock");
		FIN = GameObject.FindGameObjectsWithTag ("Finish");
		FINDAD = GameObject.FindGameObjectWithTag ("FINDAD");

		isClockFixed = false;

		for (int n = 0; n < 3; n++) {
			Destroy (clockParts [n]);
			FIN [n].GetComponent<MeshRenderer> ().enabled = true;
		}

		rotateFin = true;
	}

	public void deactivateLerp(){
		activateLerp = false;
	}
		
	void checkClock(){
		if (hourHand && minHand) {
			finishGame ();
		}
	}
		
	void Update(){
		if (startTimer) {
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0) {
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
		if (rotateFin) {
			FINDAD.transform.Rotate (Vector3.forward * Time.deltaTime * 50f);
		}
	}
		
	public void dropTrigger(string id, GameObject missingChild){
		//check if drop trigger id equates to pickedUpName, if so, put object in place by activating missingChild
	}

	public void dropLerp(GameObject missing, Vector3 pos){
		finalPos = pos;
		startTimeLerp = Time.time;
		distLerp = Vector3.Distance(missing.transform.position, finalPos);
		curr_dropoff = missing;
		activateLerp = true;
		//Lerp into place
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
		//print (id);
		if(id.Equals("platButton")){
			puzzle.GetComponent<MovingPatformController> ().toggleActive ();
		}
	}

	public void buttonDeactivate(string id, GameObject puzzle){
		//print (id);
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
	public void cPadUsed (GameObject self, string id, string direction, GameObject puzzle){
		if (isClockFixed) {
			if (id.Equals ("clockMin") || id.Equals ("clockHour")) {
				if (direction.Equals ("counterClockwise")) {
					puzzle.transform.Rotate (Vector3.right * .6f);
				} else {
					puzzle.transform.Rotate (Vector3.left * .6f);
				}
				if (handsBool(puzzle)) { // is hand in the correct place, if so check if puzzle is done
					if (id.Equals ("clockMin")) {
						minHand = true;
					} else
						hourHand = true;
					checkClock ();
				} else {
					if (id.Equals ("clockMin")) {
						minHand = false;
					} else
						hourHand = false;
				}
			}
		}
	}
	//checks to see if hand is within 10 degrees of 12 o'clock
	bool handsBool(GameObject hand){
		if (hand.transform.rotation.eulerAngles.y == 0f && hand.transform.rotation.eulerAngles.z == 0f) { //deals with wierd Euler Angle problem
			if(hand.transform.rotation.eulerAngles.x< 10f || hand.transform.rotation.eulerAngles.x > 350){
				return true;
			}
		}
		return false;
	}
	
		
}
