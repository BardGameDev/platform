using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableManager : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject == player.gameObject && player.playerRB.velocity.y < -12)
        {
            gameObject.SetActive(false);
        }
    }
}
