using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	protected readonly float STEP_ROTATE = 96f;

	private AudioSource jumpSound;

	private Rigidbody rb;

	public LayerMask groundLayer;

    private SphereCollider col;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		col = GetComponent<SphereCollider> ();
		jumpSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis ("Horizontal");
		var z = Input.GetAxis ("Vertical");

		rb.AddForce (GetRotateStep(x), 0, GetRotateStep(z));

		WatchForJump();
	}

	private bool IsGrounded() {
		return Physics.CheckCapsule (
			col.bounds.center,
			new Vector3 (col.bounds.center.x, col.bounds.min.y, col.center.z),
			col.radius * .9f,
			groundLayer
		);
	}


	void WatchForJump() {
		if (IsGrounded() && Input.GetButtonDown ("Jump")) {
			jumpSound.Play ();
			rb.AddForce (0, 100, 0, ForceMode.Impulse);
		}
	}

	float GetRotateStep(float origin) {
		if (origin == 0) {
			return 0;
		}

		// return STEP_ROTATE * origin * Time.deltaTime;
		return STEP_ROTATE * origin;
			
	}
}
