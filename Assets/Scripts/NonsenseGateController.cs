using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonsenseGateController : MonoBehaviour {

    private PlayerController player; //get a reference to the player

    [SerializeField]
    private bool firstGate = true; //gets whether "this" is the first gate

    //public bool firstGatePassed = false; //gets whether the first gate has been triggered

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            if (firstGate && player.speed > 0 && !player.firstGatePassed || !firstGate && player.speed < 0)
            {
                player.speed = -player.speed; //invert the speed to invert the controls
                player.topSpeed = player.speed * 1.2f;
                player.firstGatePassed = true; //we've passed the first gate... only possibility
            }
        }
    }
}
