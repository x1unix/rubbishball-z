using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraAltController : MonoBehaviour {
    public float turnSpeed = 4.0f;
    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        //offset = new Vector3(player.transform.position.x, player.transform.position.y + 7.0f, player.transform.position.z + 7.0f);

        offset = new Vector3(player.transform.position.x / 6, player.transform.position.y /2, player.transform.position.z / 6);
    }

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }
}
