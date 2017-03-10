using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour {

    public static int switchCount;

	static int switchNumber;

	static GameObject[] switchArray;

    static GameObject portalToUnlock;

	void Start () {
        switchCount = 0;
        switchArray = GameObject.FindGameObjectsWithTag("Switch");
        switchNumber = switchArray.Length;
        portalToUnlock = GameObject.Find("Portal");
        portalToUnlock.SetActive(false);
        Debug.LogWarning(switchCount);
        Debug.LogWarning(switchNumber);
	}
	
	void Update () {
		if (!portalToUnlock.activeSelf && switchCount >= switchNumber)
        {
            portalToUnlock.SetActive(true);
        }
	}

	public static void Reset(){
		if (portalToUnlock.activeSelf)
			portalToUnlock.SetActive(false);
		for (int x = 0; x < switchNumber; x++) {
			if (!switchArray[x].activeSelf)
				switchArray[x].SetActive(true);
		}
		switchCount = 0;
	}
}
