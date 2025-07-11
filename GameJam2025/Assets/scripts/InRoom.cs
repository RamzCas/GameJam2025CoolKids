using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRoom : MonoBehaviour
{
    public GameObject AiGamobject;
    public AI AI;
    public WalkWithPacient WalkWithPacient;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == AiGamobject) 
        {
            AI.agent.speed = AI.MinSpeed;
            WalkWithPacient.LeftAlone = false;
        }
    }
}
