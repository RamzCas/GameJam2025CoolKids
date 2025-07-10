using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerSwitch : MonoBehaviour
{
    public bool PowerOn;
    public GameObject[] Lights;

    private void Awake()
    {
       

    }
    void Update()
    {
        LightControls();
    }


    public void LightControls() 
    {
        if (PowerOn == true)
        {
            foreach( var item in Lights ) 
            { 
                item.SetActive(true);
            }
        }

        if (PowerOn == false)
        {
            foreach (var item in Lights)
            {
                item.SetActive(false);
            }
        }
    }
}
