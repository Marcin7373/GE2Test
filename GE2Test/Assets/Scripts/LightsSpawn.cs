using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsSpawn : MonoBehaviour
{
    public float radius = 9;
    public int lightNum = 10;
    private float angle = 0, height;
    private Vector3[] waypoints;
    public GameObject trafficLight, car;

    void OnEnable()
    {
        height = transform.position.y - (trafficLight.transform.localScale.y / 2);
        waypoints = new Vector3[lightNum];

        for (int i = 0; i < lightNum; i++)
        {
            waypoints[i] = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * radius, height, Mathf.Sin(angle * Mathf.Deg2Rad) * radius);
            angle += 360 / lightNum;
        }

        for (int i = 0; i < lightNum; i++)
        {
            trafficLight = Instantiate(trafficLight, waypoints[i], trafficLight.transform.rotation);
        }

        car = Instantiate(car, transform.position, car.transform.rotation);
    }
}
