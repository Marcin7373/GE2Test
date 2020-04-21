using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ChooseLight : State
{
    public override void Enter()
    {
        GameObject[] lights = GameObject.FindGameObjectsWithTag("GreenLight");
        GameObject target = lights[Random.Range(0, lights.Length)];

        while (target == owner.GetComponent<CarController>().lightTarget)
        {
            target = lights[Random.Range(0, lights.Length - 1)];
        }
        owner.GetComponent<CarController>().lightTarget = target;
        owner.GetComponent<Arrive>().targetGameObject = target;
        owner.GetComponent<Arrive>().enabled = true;
        owner.GetComponent<StateMachine>().RevertToPreviousState();
    }
}

class DetectTarget : State
{
    public override void Enter()
    {
        if (owner.GetComponent<CarController>().lightTarget == null)
        {
            owner.GetComponent<StateMachine>().ChangeState(new ChooseLight());
        }
    }

    public override void Think()
    {
        GameObject target = owner.GetComponent<CarController>().lightTarget;
        //Debug.Log((target.transform.position - owner.transform.position).magnitude);
        if ((target.transform.position - owner.transform.position).magnitude < 2f || target.tag == "NotGreenLight")
        {
            owner.GetComponent<StateMachine>().RevertToPreviousState();
        }
    }
}

public class CarController : MonoBehaviour
{
    public GameObject lightTarget = null;

    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new DetectTarget());
    }
}
