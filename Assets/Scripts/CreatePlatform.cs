using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatform : MonoBehaviour
{
    //Parent
    private GameObject Ground;
    private GameObject Build;
    private GameObject Background;

    public GameObject Footpath;
    public GameObject CreateFootpathPos;
    private float FootpathWidth;

    public GameObject Road;
    public GameObject CreateRoadPos;
    private float RoadWidth;

    public GameObject BG;
    public GameObject CreateBGPos;
    private float BGWidth;

    public GameObject BGBuild1;
    public GameObject CreateBGBuild1Pos;
    private float BGBuild1Width;

    public GameObject BGBuild2;
    public GameObject CreateBGBuild2Pos;
    private float BGBuild2Width;

    private GameObject Building;
    public GameObject CreateBuildingPos;
    private float BuildingWidth;

    private ParticleSystem PRain;
    public GameObject CreateRainPos;
    private float RainWidth;

    public Transform CreatePoint;
    public int Distance;
    private int DistancePos;
    private int RandBuilding;

    // Use this for initialization
    void Start()
    {
        Ground = GameObject.Find("Ground");
        Background = GameObject.Find("Background");
        Build = GameObject.Find("Building");

        CreateFootpathPos.transform.position = new Vector3(Footpath.transform.position.x, Footpath.transform.position.y, Footpath.transform.position.z);
        FootpathWidth = Footpath.GetComponent<BoxCollider2D>().bounds.size.x;
        RoadWidth = Road.GetComponent<BoxCollider2D>().bounds.size.x;
        BGWidth = BG.GetComponent<BoxCollider2D>().bounds.size.x;
        BGBuild1Width = BGBuild1.GetComponent<BoxCollider2D>().bounds.size.x;
        BGBuild2Width = BGBuild2.GetComponent<BoxCollider2D>().bounds.size.x;
        RainWidth = 11.8f;
        CreateStartBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        CreatePlatforms();
        CreateBuilding();
    }

    private void CreatePlatforms()
    {
        if (CreateFootpathPos.transform.position.x < CreatePoint.position.x)
        {
            CreateFootpathPos.transform.position = new Vector3(CreateFootpathPos.transform.position.x + FootpathWidth, CreateFootpathPos.transform.position.y, CreateFootpathPos.transform.position.z);
            Footpath = Instantiate(Footpath, CreateFootpathPos.transform.position, CreateFootpathPos.transform.rotation) as GameObject;
            Footpath.transform.parent = Ground.transform;
        }

        if (CreateRoadPos.transform.position.x < CreatePoint.position.x)
        {
            CreateRoadPos.transform.position = new Vector3(CreateRoadPos.transform.position.x + RoadWidth, CreateRoadPos.transform.position.y, CreateRoadPos.transform.position.z);
            Road = Instantiate(Road, CreateRoadPos.transform.position, CreateRoadPos.transform.rotation) as GameObject;
            Road.transform.parent = Ground.transform;
        }

        if (CreateBGPos.transform.position.x < CreatePoint.position.x)
        {
            CreateBGPos.transform.position = new Vector3(CreateBGPos.transform.position.x + BGWidth, CreateBGPos.transform.position.y, CreateBGPos.transform.position.z);
            BG = Instantiate(BG, CreateBGPos.transform.position, CreateBGPos.transform.rotation) as GameObject;
            BG.transform.parent = Background.transform; 
        }

        if (CreateBGBuild1Pos.transform.position.x < CreatePoint.position.x)
        {
            CreateBGBuild1Pos.transform.position = new Vector3(CreateBGBuild1Pos.transform.position.x + BGBuild1Width, CreateBGBuild1Pos.transform.position.y, CreateBGBuild1Pos.transform.position.z);
            BGBuild1 = Instantiate(BGBuild1, CreateBGBuild1Pos.transform.position, CreateBGBuild1Pos.transform.rotation) as GameObject;
            BGBuild1.transform.parent = Background.transform;
        }

        if (CreateBGBuild2Pos.transform.position.x < CreatePoint.position.x)
        {
            CreateBGBuild2Pos.transform.position = new Vector3(CreateBGBuild2Pos.transform.position.x + BGBuild2Width, CreateBGBuild2Pos.transform.position.y, CreateBGBuild2Pos.transform.position.z);
            BGBuild2 = Instantiate(BGBuild2, CreateBGBuild2Pos.transform.position, CreateBGBuild2Pos.transform.rotation) as GameObject;
            BGBuild2.transform.parent = Background.transform;
        }
        if (CreateRainPos.transform.position.x < CreatePoint.position.x)
        {
            CreateRainPos.transform.position = new Vector3(CreateRainPos.transform.position.x + RainWidth, CreateRainPos.transform.position.y, CreateRainPos.transform.position.z);
            PRain = Instantiate(Resources.Load("Rain"), CreateRainPos.transform.position, CreateRainPos.transform.rotation) as ParticleSystem;
        }
    }

    private void CreateStartBuilding()
    {
        RandBuilding = (int)Random.Range(1, 11);
        Building = Instantiate(Resources.Load("Building "+ RandBuilding.ToString(), typeof(GameObject)), CreateBuildingPos.transform.position, CreateBuildingPos.transform.rotation) as GameObject;
        BuildingWidth = Building.GetComponent<BoxCollider2D>().bounds.size.x;
        DistancePos = (int)Random.Range(1, Distance);
        CreateBuildingPos.transform.position = new Vector3(CreateBuildingPos.transform.position.x + BuildingWidth + DistancePos, CreateBuildingPos.transform.position.y, CreateBuildingPos.transform.position.z);
        Building.transform.parent = Build.transform;
    }

    private void CreateBuilding()
    {
        if (CreateBuildingPos.transform.position.x < CreatePoint.position.x)
        {
            RandBuilding = (int)Random.Range(1, 13);
            if (RandBuilding >= 1 && RandBuilding <= 10)
            {
                Building = Instantiate(Resources.Load("Building " + RandBuilding.ToString(), typeof(GameObject)), CreateBuildingPos.transform.position, CreateBuildingPos.transform.rotation) as GameObject;
                BuildingWidth = Building.GetComponent<BoxCollider2D>().bounds.size.x;
                DistancePos = (int)Random.Range(2, Distance);
                CreateBuildingPos.transform.position = new Vector3(CreateBuildingPos.transform.position.x + BuildingWidth + DistancePos, CreateBuildingPos.transform.position.y, CreateBuildingPos.transform.position.z);
                Building.transform.parent = Build.transform;
            }
            else
            {
                CreateBuildingPos.transform.position = new Vector3(CreateBuildingPos.transform.position.x, CreateBuildingPos.transform.position.y - 0.55f, CreateBuildingPos.transform.position.z);
                Building = Instantiate(Resources.Load("Building " + RandBuilding.ToString(), typeof(GameObject)), CreateBuildingPos.transform.position, CreateBuildingPos.transform.rotation) as GameObject;
                BuildingWidth = Building.GetComponent<BoxCollider2D>().bounds.size.x;
                DistancePos = (int)Random.Range(2, Distance);
                CreateBuildingPos.transform.position = new Vector3(CreateBuildingPos.transform.position.x + BuildingWidth + DistancePos, CreateBuildingPos.transform.position.y + 0.55f, CreateBuildingPos.transform.position.z);
                Building.transform.parent = Build.transform;
            }
        }
    }
}
