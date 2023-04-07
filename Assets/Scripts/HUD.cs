using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text Health;
    public Text Item;
    public Text Distance;

    public int LifeItem = 100;
    public float Score;
    public float HighScore;

    public Scrollbar HealthBar;
    public Scrollbar ItemBar;

    public HUD Hud;
    public Player player;

    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore",0);
    }
    
    void Update ()
    {
        //Show Item Bar      
        if (LifeItem <= 0)
        {
            Transform colUmbella = GameObject.Find("Player").transform.Find("ColUmbella");
            colUmbella.gameObject.SetActive(false);
            player.Umbella = false;

            Transform colBox = GameObject.Find("Player").transform.Find("ColBox");
            colBox.gameObject.SetActive(false);
            player.Box = false;

            Item.text = (LifeItem.ToString() + "%");
            GameObject.Find("Canvas").transform.Find("ItemBar").gameObject.active = false;
        }

        //Health Bar
        if (player.CurHealth <= 100)
        {
            Health.text = (player.CurHealth.ToString() + "%");
            HealthBar.size = player.CurHealth / 100f;
        }

        //Item Bar
        if ((player.Umbella || player.Box))
        {
            Item.text = (LifeItem.ToString() + "%");
            ItemBar.size = Hud.LifeItem / 100f;
        }

        //Score
        Score = player.transform.position.x;
        if(Score >=0 ) Distance.text = (int)Score + " m ";
    }
}
