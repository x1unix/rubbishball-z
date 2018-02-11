using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;


    public float sensitivity = 10f;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;

    // Use this for initialization
    void Start () {
		offset = transform.position - player.transform.position;
	}

    public void Update()
    {
        this.FollowPlayer();
    }

    public void MouseRotate()
    {
        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        //currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        //currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
        // currentRotation.y = 0;
        currentRotation.y = 45;
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
    }

    void FollowPlayer() {
        var rotateLeft = Input.GetKey(KeyCode.Q);
        var rotateRight = Input.GetKey(KeyCode.E);

        this.MouseRotate();

        if (rotateLeft || rotateRight)
        {
            var pos = transform.position;
            var shift = rotateLeft ? -1f : 1f;
            // ---transform.Rotate (0,shift,0, Space.World);
            transform.RotateAround(player.transform.position, new Vector3(1, 0, 0), shift);
        }
    }
	
	// Update is called once per frame
	void LateUpdate () {
		// Set camera's transform position to be the same as player's but offset by the calculated offset distance.
		if (player == null) return;
		transform.position = player.transform.position + offset;


	}
}
