using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStumble : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
        }
    }
}
