﻿using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public GameObject respawnable;
	public scrollscript scroller;
	public LayerMask mask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void respawn(){
		GameObject newPlayer = (GameObject)Instantiate(respawnable);
		newPlayer.transform.position = this.transform.position;
		
		smooth2Dfollow sm2df = Camera.main.GetComponent<smooth2Dfollow>();
		
		sm2df.target = newPlayer.transform;
		
		scrolltriggerscript scrolltrigger = newPlayer.GetComponent<scrolltriggerscript>();
		scrolltrigger.cam = Camera.main;
		scrolltrigger.playerFollower = sm2df;
		scrolltrigger.scroller = scroller;
		
		Head newHead = newPlayer.GetComponent<Head>();
		newHead.successor = null;
		newHead.mask = mask;
		newHead.newSeg = Resources.Load<GameObject>("Segment");
		newHead.grounded = true;
		
		for(int i = 0; i < 5; i++){
			newHead.growNewSegment();
		}
		
		
	}
}