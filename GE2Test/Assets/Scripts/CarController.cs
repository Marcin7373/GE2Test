using UnityEngine;

class ChooseLight : State
{
    public override void Think()//think instead of enter to redo no green lights
    {
        if (GameObject.FindGameObjectsWithTag("GreenLight").Length != 0)
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
            owner.RevertToPreviousState();
        }
    }
}

class DetectTarget : State
{
    public override void Enter()//allows for reverting between states
    {
        if (owner.GetComponent<CarController>().lightTarget == null)
        {
            owner.GetComponent<StateMachine>().ChangeState(new ChooseLight());
        }
    }

    public override void Think()
    {   //checks if within distance or if tag changed
        GameObject target = owner.GetComponent<CarController>().lightTarget;
        if ((target.transform.position - owner.transform.position).magnitude < 3f || target.tag == "NotGreenLight")
        {
            //owner.GetComponent<Arrive>().enabled = false;
            owner.RevertToPreviousState();
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
