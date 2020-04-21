using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightSwitching : MonoBehaviour
{
    [HideInInspector]
    public int state = 0; //0=green, 1=yellow, 2=red

    void Start()
    {
        state = Random.Range(0,2);
        StartCoroutine(LightDelay());
    }

    IEnumerator LightDelay()
    {
        while (true)
        {
            if (state == 0)
            {
                GetComponent<Renderer>().material.color = Color.green;
                yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
                state = 1;           
            }
            else if (state == 1)
            {
                GetComponent<Renderer>().material.color = Color.yellow;
                yield return new WaitForSeconds(4);
                state = 2;          
            }
            else if (state == 2)
            {
                GetComponent<Renderer>().material.color = Color.red;
                yield return new WaitForSeconds(Random.Range(5.0f,10.0f));
                state = 0;        
            }
        }
    }
}
