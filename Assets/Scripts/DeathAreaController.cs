﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAreaController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.tag == "Player") // this string is your newly created tag
		{
			// TODO: anything you want
			// Even you can get Bullet object
			//GameObject strikingBullet = collider.gameObject;
			Destroy(collider.gameObject);
			EventManager.TriggerEvent ("die");
		}
	}
}
