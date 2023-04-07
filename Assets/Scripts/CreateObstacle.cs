using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject CObstacle;
    public GameObject CreateCObstaclePos;
    public GameObject DestroyPos;

    private GameObject PObstacle;   //Parent
    
    private bool CreatedCObstacle = false;
    private int RandCObstacle;
    private int RandTime;

    void Start()
    {
        PObstacle = GameObject.Find("Obstacle");
        StartCoroutine(CreateCObstacles());
    }

    void Update()
    {
        if (CreatedCObstacle && CObstacle != null)
        {
            if (CObstacle.transform.position.x < DestroyPos.transform.position.x)
            {
                Destroy(CObstacle);
                StartCoroutine(CreateCObstacles());
            }
        }
    }

    IEnumerator CreateCObstacles()
    {
        CreatedCObstacle = false;
        RandTime = (int)Random.Range(3, 6);
        yield return new WaitForSeconds(RandTime);

        if (CreatedCObstacle == false)
        {
            RandCObstacle = (int)Random.Range(1, 3);
            CreateCObstaclePos.transform.position = new Vector3(CreateCObstaclePos.transform.position.x, CreateCObstaclePos.transform.position.y, CreateCObstaclePos.transform.position.z);
            CObstacle = Instantiate(Resources.Load("Obstacle " + RandCObstacle.ToString(), typeof(GameObject)), CreateCObstaclePos.transform.position, CreateCObstaclePos.transform.rotation) as GameObject;
            CObstacle.transform.parent = PObstacle.transform;
        }
        CreatedCObstacle = true;
    }
}
