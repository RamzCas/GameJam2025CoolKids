using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public Timer timer;
    public FirstPersonControls firstPersonControls;
    void Update()
    {
        if(timer.TimeRemanding <= 0) 
        {
            Debug.Log("EndGameFail");
        }

        if(firstPersonControls.PacientsRemanding <= 0 ) 
        {
            Debug.Log("EndGamesucess");
        }
    }
}
