using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class DeathScreenController : MonoBehaviour {

	private UnityAction playerDeadListener;

	public Canvas canvas;

	public AudioSource wastedSound;

	// Use this for initialization
	void Start () {
		playerDeadListener = new UnityAction (onPlayerDie);
		EventManager.StartListening ("die", playerDeadListener);
	}

	void OnEnable() {
		
		//canvas = GetComponent<Canvas> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnDisable() {
		// EventManager.StopListening ("die", playerDeadListener);
	}


	void onPlayerDie() {
		print ("Player 1 is dead Xb");
		canvas.enabled = true;
		wastedSound.Play ();
	}
}
