using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {
    public GameObject ConfirmUI;
    private string FirstPlay;
    private AudioSource As;
    public AudioClip Ac;
	// Use this for initialization
	void Start () {
        FirstPlay = PlayerPrefs.GetString("First","Yes");
        /*PlayerPrefs.SetString("First","Yes");
        FirstPlay= PlayerPrefs.GetString("First", "Yes");*/
        As = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            As.PlayOneShot(Ac, 1f);
            if (FirstPlay == "Yes")
            {
                Application.LoadLevel("Tutorial");
            }
            else Application.LoadLevel("Game");
        }
	}

    public void Exit()
    {
        As.PlayOneShot(Ac,1f);
        ConfirmUI.SetActive(true);
    }

    public void Yes()
    {
        As.PlayOneShot(Ac, 1f);
        Application.Quit();
    }

    public void No()
    {
        As.PlayOneShot(Ac, 1f);
        ConfirmUI.SetActive(false);
    }
}
