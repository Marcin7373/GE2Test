using System.Collections;
using UnityEngine;

public class TrafficLightSwitching : MonoBehaviour
{
    [HideInInspector]
    public int state = 0; //0=green, 1=yellow, 2=red

    void Start()
    {
        state = Random.Range(0,3); // for int max = exclusive so < 3, for float max = inclusive
        StartCoroutine(LightDelay());
    }

    IEnumerator LightDelay()
    {
        while (true)
        {
            if (state == 0)
            {
                GetComponent<Renderer>().material.color = Color.green;
                gameObject.tag = "GreenLight";
                state = 1;
                yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
            }
            else if (state == 1)
            {
                GetComponent<Renderer>().material.color = Color.yellow;
                gameObject.tag = "NotGreenLight";
                state = 2;
                yield return new WaitForSeconds(4);   
            }
            else if (state == 2)
            {
                GetComponent<Renderer>().material.color = Color.red;
                gameObject.tag = "NotGreenLight";
                state = 0;
                yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));        
            }
        }
    }
}
