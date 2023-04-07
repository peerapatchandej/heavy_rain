using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRain : MonoBehaviour {
    private Player player;
    public HUD Hud;
	void Start () {
        player = GetComponentInParent<Player>();
        Hud = GameObject.Find("ProcessBG").GetComponent<HUD>();
    }
   
    void OnParticleCollision(GameObject other)
    {
        other = GameObject.Find("Player");
        Debug.Log(other.CompareTag("Item"));
        if (GameObject.Find("Player").transform.Find("ColUmbella").gameObject.active == true || GameObject.Find("Player").transform.Find("ColBox").gameObject.active == true)
        {
            Hud.LifeItem -= 5;
        }
        else if (GameObject.Find("Player").transform.Find("ColUmbella").gameObject.active == false ||
            GameObject.Find("Player").transform.Find("ColBox").gameObject.active == false)
        {
            player.CurHealth += 5; 
        }
            
    }
}
