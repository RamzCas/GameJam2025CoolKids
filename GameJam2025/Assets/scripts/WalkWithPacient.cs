using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkWithPacient : MonoBehaviour
{
    public AI AI;
    public float timer;
    public bool LeftAlone;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && AI.shot == true) 
        {
            AI.agent.speed = AI.Walkspeed;
            LeftAlone = false;
            timer = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && AI.shot == true)
        {
            AI.agent.speed = AI.MinSpeed;
            LeftAlone = true;
        }
    }

    private void Update()
    {
        if (LeftAlone == true) 
        {
            timer += Time.deltaTime;
        }

        if (timer > 5) 
        {
            AI.PosNumber = 0;
            AI.shot = false;
            LeftAlone = false;
            timer = 0;
            AI.agent.speed = AI.MaxSpeed;
            AI.TargetGameObject.transform.position = AI.P1.transform.position;
        }
    }
}
