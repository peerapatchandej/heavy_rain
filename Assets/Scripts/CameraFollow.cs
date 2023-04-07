using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Vector2 Velocity;
    public float smoothTimeX;
    public float smoothTimeY;
    public GameObject Player;
    public Vector3 minCameraPos;

    void Start () {
        //Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref Velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref Velocity.y, smoothTimeY);

        transform.position = new Vector3(posX,posY, transform.position.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, Mathf.Infinity),
            Mathf.Clamp(transform.position.y, minCameraPos.y, Mathf.Infinity),
            Mathf.Clamp(transform.position.z, minCameraPos.z, Mathf.Infinity));

        minCameraPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
