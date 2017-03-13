﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidAirBoost : MonoBehaviour {

    //private Rigidbody playerRB;
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
        if (Other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            player.playerRB.velocity = new Vector3(player.playerRB.velocity.x, player.playerRB.velocity.y + player.jumpSpeed/50, player.playerRB.velocity.z);
        }
    }
}