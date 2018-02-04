using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	protected readonly float STEP_ROTATE = 96f;

	protected readonly float JUMP_VELOCITY = 32f;

	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;

	AudioSource jumpSound;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		jumpSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		var x = Input.GetAxis ("Horizontal");
		var z = Input.GetAxis ("Vertical");

		rb.AddForce (GetRotateStep(x), 0, GetRotateStep(z));

		HandleJumpControl();
	}



	void HandleJumpControl() {
		TrackJumpGravityState ();
		if (Input.GetButtonDown ("Jump")) {
			GetComponent<Rigidbody> ().velocity = Vector2.up * JUMP_VELOCITY;
			jumpSound.Play ();
		}
	}

	bool TrackJumpGravityState() {
		bool isFalling = rb.velocity.y > 0;
		float fallVelocity = rb.velocity.y;
		if (fallVelocity < 0) {
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		} else if (fallVelocity > 0 && !Input.GetButton ("Jump")) {
			rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}

		return isFalling;
	}

	float GetRotateStep(float origin) {
		if (origin == 0) {
			return 0;
		}

		// return STEP_ROTATE * origin * Time.deltaTime;
		return STEP_ROTATE * origin;
			
	}
}
