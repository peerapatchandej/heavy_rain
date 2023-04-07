using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject ConfirmUI;
    public GameObject ResultUI;
    private bool pause = false;

    public Player player;
    public HUD Hud;

    public AudioSource As;
    public AudioClip Ac;

    void Start()
    {
        As = GetComponent<AudioSource>();
    }
	// Update is called once per frame
	void Update ()
    {
        //Pause UI
        if (Input.GetButtonDown("Pause") && ResultUI.active == false)
        {
            As.PlayOneShot(Ac, 1.0f);
            pause = !pause;
        }
        if (pause)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!pause && ResultUI.active == false)
        {
            PauseUI.SetActive(false);
            ConfirmUI.SetActive(false);
            Time.timeScale = 1;
        }

        //Result UI
        if (player.Die)
        {
            if (Hud.HighScore < Hud.Score)
            {
                PlayerPrefs.SetInt("HighScore", (int)Hud.Score);
            }

            ResultUI.SetActive(true);
            if (Hud.Score < 0.0f) Hud.Score = 0.0f; 
            ResultUI.transform.Find("Score").GetComponent<Text>().text = ((int)Hud.Score).ToString();
            ResultUI.transform.Find("BestScore").GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }

    public void Resume()
    {
        As.PlayOneShot(Ac, 1.0f);
        pause = false;
    }

    public void Home()
    {
        As.PlayOneShot(Ac, 1.0f);
        ConfirmUI.SetActive(true);
    }

    public void Yes()
    {
        As.PlayOneShot(Ac, 1.0f);
        pause = false;
        Application.LoadLevel("Home");
    }

    public void No()
    {
        As.PlayOneShot(Ac, 1.0f);
        pause = false;
        ConfirmUI.SetActive(false);
    }

    public void Restart()
    {
        As.PlayOneShot(Ac, 1.0f);
        pause = false;
        Application.LoadLevel("Game");
    }
}
