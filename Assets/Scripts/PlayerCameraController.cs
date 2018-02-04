using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
	float distance;

	Vector3 playerPrevPos, playerMoveDir;


	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		distance = offset.magnitude;
		playerPrevPos = player.transform.position;
	}

	void Update() {
		var rotateLeft = Input.GetKey (KeyCode.Q);
		var rotateRight = Input.GetKey (KeyCode.E);

		if (rotateLeft || rotateRight) {
			var pos = transform.position;
			var shift = rotateLeft ? -1f : 1f;
			//transform.Rotate (0,shift,0, Space.World);
			transform.RotateAround(player.transform.position, new Vector3(1,0,0), shift);
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		// Set camera's transform position to be the same as player's but offset by the calculated offset distance.
		if (player == null) return;
		transform.position = player.transform.position + offset;


	}
}
