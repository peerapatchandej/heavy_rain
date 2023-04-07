using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCar : MonoBehaviour
{
    private GameObject Car; //Parent;

    private GameObject Car1;
    public GameObject CreateCarPos1;

    private GameObject Car2;
    public GameObject CreateCarPos2;

    public GameObject DestroyPos;

    private bool CreatedCar1 = false;
    private bool CreatedCar2 = false;

    private int RandCar1;
    private int RandCar2;
    private int RandTime1;
    private int RandTime2;

    private AudioSource As;
    public AudioClip[] Ac;

    void Start()
    {
        Car = GameObject.Find("Car");
        StartCoroutine(CreateCars1());
        StartCoroutine(CreateCars2());
        As = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (CreatedCar1)
        {
            if (Car1.transform.position.x > DestroyPos.transform.position.x)
            {
                Car1.transform.position = new Vector3(Car1.transform.position.x - 0.1f, Car1.transform.position.y, Car1.transform.position.z);
            }
            else
            {
                Destroy(Car1);
                StartCoroutine(CreateCars1());
            }
        }
        if (CreatedCar2)
        {
            if (Car2.transform.position.x > DestroyPos.transform.position.x)
            {
                Car2.transform.position = new Vector3(Car2.transform.position.x - 0.1f, Car2.transform.position.y, Car2.transform.position.z);
            }
            else
            {
                Destroy(Car2);
                StartCoroutine(CreateCars2());
            }
        }
    }

    IEnumerator CreateCars1()
    {
        CreatedCar1 = false;
        RandTime1 = (int)Random.Range(5, 11);
        yield return new WaitForSeconds(RandTime1);
        
        if (CreatedCar1 == false)
        {
            RandCar1 = (int)Random.Range(1, 7);

            if (RandCar1 >= 1 && RandCar1 <= 3) //Bus
            {
                As.PlayOneShot(Ac[0], 0.3f);
            }
            else As.PlayOneShot(Ac[1], 0.3f); //Car

            
            Car1 = Instantiate(Resources.Load("Car "+RandCar1.ToString(), typeof(GameObject)), CreateCarPos1.transform.position, CreateCarPos1.transform.rotation) as GameObject;
            Car1.layer = Car1.layer++;
            Car1.transform.parent = Car.transform;
        }
        CreatedCar1 = true;
    }

    IEnumerator CreateCars2()
    {
        CreatedCar2 = false;
        RandTime2 = (int)Random.Range(5, 11);
        yield return new WaitForSeconds(RandTime2);
        
        if (CreatedCar2 == false)
        {
            RandCar2 = (int)Random.Range(1, 7);

            if (RandCar2 >= 1 && RandCar2 <= 3) //Bus
            {
                As.PlayOneShot(Ac[0], 0.3f);
            }
            else As.PlayOneShot(Ac[1], 0.3f); //Car

            
            Car2 = Instantiate(Resources.Load("Car " + RandCar2.ToString(), typeof(GameObject)), CreateCarPos2.transform.position, CreateCarPos2.transform.rotation) as GameObject;
            //Car2.layer = Car2.layer++;
            Car2.transform.parent = Car.transform;
        }
        CreatedCar2 = true;
    }
}
