using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ChooseLight : State
{
    public override void Enter()
    {
        GameObject[] lights = GameObject.FindGameObjectsWithTag("GreenLight");
        GameObject target = lights[Random.Range(0, lights.Length-1)];

        while (target == owner.GetComponent<CarController>().lightTarget)
        {
            target = lights[Random.Range(0, lights.Length - 1)];
        }
        owner.GetComponent<CarController>().lightTarget = target;
        owner.GetComponent<Arrive>().targetGameObject = target;
        owner.GetComponent<Arrive>().enabled = true;
    }
}

public class CarController : MonoBehaviour
{
    public GameObject[] tLights;
    public GameObject lightTarget;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
