using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public Timer timer;
    public FirstPersonControls firstPersonControls;

    public GameObject winScreen;
    public GameObject loseScreen;

    void Update()
    {
        if(timer.TimeRemanding <= 0) 
        {
            Debug.Log("EndGameFail");
            loseScreen.SetActive(true);
        }

        if(firstPersonControls.PacientsRemanding <= 0 ) 
        {
            Debug.Log("EndGamesucess");
            winScreen.SetActive(true);
        }
    }
}
