using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    private Player player;

	void Start()
    {
        player = GetComponentInParent<Player>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            player.Grounded = true;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground")) player.Grounded = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ground")) player.Grounded = false;
    }
}
