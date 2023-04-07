using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    public GameObject CItem;
    public GameObject CreateCItemPos;
    public GameObject DestroyPos;

    private GameObject PItem; //Parent;

    public bool CreatedCItem = false;
    private int RandCItem;
    private int RandTime;

    public string Type;
    public float WaitForTime;
    public float LifeTime = 10.0f;

    void Start()
    {
        PItem = GameObject.Find("Item");
        WaitForTime = (int)Random.Range(10, 20);
    }

    void Update()
    {
        if (CreatedCItem && CItem != null)
        {
            if (CItem.transform.position.x < DestroyPos.transform.position.x)
            {
                ResetTime();
                CreateCItem();
            }
            LifeItem();
        }
        if (CreatedCItem == false)
        {
            CreateCItem();
        }
    }

    public void CreateCItem()
    {
        Destroy(CItem);
        CreatedCItem = false;
        WaitForTime -= Time.deltaTime;

        if (WaitForTime <= 0)
        {
            if (CreatedCItem == false)
            {
                RandCItem = (int)Random.Range(1, 3);
                CreateCItemPos.transform.position = new Vector3(CreateCItemPos.transform.position.x, CreateCItemPos.transform.position.y, CreateCItemPos.transform.position.z);
                CItem = Instantiate(Resources.Load("Item " + RandCItem.ToString(), typeof(GameObject)), CreateCItemPos.transform.position, CreateCItemPos.transform.rotation) as GameObject;
                CItem.transform.parent = PItem.transform;

                if (RandCItem == 1) Type = "Box";
                else if (RandCItem == 2) Type = "Umbella";
            }
            CreatedCItem = true;
        }
    }

    public void LifeItem()
    {
        LifeTime -= Time.deltaTime;

        if (LifeTime <= 0)
        {
            ResetTime();
            CreateCItem();
        }
    }

    public void ResetTime()
    {
        WaitForTime = (float)Random.Range(10, 20);
        LifeTime = 10.0f;
    }
}
