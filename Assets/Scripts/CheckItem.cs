using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckItem : MonoBehaviour {
    private GameObject PNotification;
    private GameObject CNotification;
    private Player player;
    private CreateItem Item;
    private float PosX;
    private float PosY;
    private float PosZ;
    private GameObject ColUmbella;
    private HUD Hud;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Item = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CreateItem>();
        Hud = GameObject.Find("ProcessBG").GetComponent<HUD>();

        if (GameObject.Find("Notification") != null && (Item.CreatedCItem && Item.CItem != null)) PNotification = GameObject.Find("Notification");
        else PNotification = new GameObject("Notification");

        PosX = GameObject.FindGameObjectWithTag("Item").transform.position.x;
        PosY = GameObject.FindGameObjectWithTag("Item").transform.position.y + 0.90f;
        PosZ = GameObject.FindGameObjectWithTag("Item").transform.position.z;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (GameObject.Find("Notification") == null && (Item.CreatedCItem && Item.CItem != null)) PNotification = new GameObject("Notification");

            CNotification = Instantiate(Resources.Load("CNotification"), new Vector3(PosX, PosY, PosZ), GameObject.FindGameObjectWithTag("Item").transform.rotation) as GameObject;
            CNotification.transform.parent = PNotification.transform;

            if (Input.GetButtonDown("Submit") && player.Grounded)
            {
                Hud.LifeItem = 100;
                if (Item.Type == "Umbella")
                {
                    player.Box = false;
                    Transform colBox = GameObject.Find("Player").transform.Find("ColBox");
                    colBox.gameObject.SetActive(false);

                    player.Umbella = true;
                    Transform colUmbella = GameObject.Find("Player").transform.Find("ColUmbella");
                    colUmbella.gameObject.SetActive(true);
                }
                if (Item.Type == "Box")
                {
                    player.Umbella = false;
                    Transform colUmbella = GameObject.Find("Player").transform.Find("ColUmbella");
                    colUmbella.gameObject.SetActive(false);

                    player.Box = true;
                    Transform colBox = GameObject.Find("Player").transform.Find("ColBox");
                    colBox.gameObject.SetActive(true);  
                }
                GameObject.Find("Canvas").transform.Find("ItemBar").gameObject.active = true;
                Destroy(PNotification);
                Item.ResetTime();
                Item.CreateCItem();
            }
        }
    }
}
