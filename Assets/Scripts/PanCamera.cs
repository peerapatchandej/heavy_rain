using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamera : MonoBehaviour {
    public Camera Cam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Cam.transform.position = new Vector3(Cam.transform.position.x + 0.03f, Cam.transform.position.y, Cam.transform.position.z);
	}
}
