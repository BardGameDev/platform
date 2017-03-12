using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour {

    private GameObject teleportEnter;

    private Transform teleportDest;

	// Use this for initialization
	void Start () {
        teleportEnter = GameObject.Find("TeleportEnter");
        teleportDest = GameObject.Find("TeleportDest").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            Other.GetComponent<Rigidbody>().transform.position = new Vector3(teleportDest.position.x, teleportDest.position.y, teleportDest.position.z);
        }
    }
}
