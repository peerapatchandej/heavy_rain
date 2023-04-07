using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNotification : MonoBehaviour {
    public GameObject PNotification;

    void Start()
    {
        PNotification = GameObject.Find("Notification");
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CreateItem>().CItem == null) 
        {
            Destroy(PNotification);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(PNotification);
        }
    }
}
