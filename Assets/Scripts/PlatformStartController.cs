using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStartController : MonoBehaviour {
	public Transform leftPlatforms;
	public Transform rightPlatforms;
	private bool TouchedForTheVeryFirstTime = true;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("PlayerTrigger") && TouchedForTheVeryFirstTime) {
			print ("DONT TOUCH ME EVER AGAIN");
			TouchedForTheVeryFirstTime = false;
			StartCoroutine(movePlatforms());
		}
	}

	IEnumerator movePlatforms(){
		foreach(Transform platform in leftPlatforms){
			platform.gameObject.GetComponent<MovingPatformController> ().toggleActive();
		}
		yield return new WaitForSeconds (1.7f);

		foreach(Transform platform in rightPlatforms){
			platform.gameObject.GetComponent<MovingPatformController> ().toggleActive();
		}
	}
}
