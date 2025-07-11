using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRoom : MonoBehaviour
{
    public GameObject AiGamobject;
    public AI AI;
    public FirstPersonControls FirstPersonControls;
    public WalkWithPacient WalkWithPacient;
    public GameObject WalkObject;
    public GameObject Door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AI"))
        {
            Debug.Log("AI off");
            AI.agent.speed = AI.MinSpeed;
            WalkWithPacient.LeftAlone = false;
            Destroy(WalkObject);
            Door.SetActive(true);
            FirstPersonControls.PacientsRemanding -= 1;
            //AI.agent.enabled = false;
        }
    }
}
