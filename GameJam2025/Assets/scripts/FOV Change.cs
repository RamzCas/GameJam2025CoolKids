using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVChange : MonoBehaviour
{
    public Timer Timer;
    public Camera PlayerCam;
    public float CurrentFOV;
    public float MaxFOV;
    public float MinFOV;


    private void Update()
    {
        CurrentFOV = Timer.TimeRemanding;
        PlayerCam.fieldOfView = Timer.TimeRemanding;


        if(Timer.TimeRemanding >= MaxFOV) 
        {
            PlayerCam.fieldOfView = MaxFOV;    
            Timer.TimeRemanding = MaxFOV;
        }

        if(Timer.TimeRemanding <= MinFOV) 
        {
            PlayerCam.fieldOfView = MinFOV;
        }
    }
}
