using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
    public GameObject DestroyPos;
	
    void Start()
    {
        DestroyPos = GameObject.Find("DestroyPos");
    }
	// Update is called once per frame
	void Update () {
        if (transform.position.x < DestroyPos.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
