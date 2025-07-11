using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Target;
    public GameObject TargetGameObject;
    public float PosNumber;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;

    [Header("Ai settings")]
    public float MaxSpeed;
    public float Walkspeed;
    public float MinSpeed;
    public bool shot;

    [Header("Room stuff")]
    public GameObject RoomPt;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = Target.position;
        MoveTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject == TargetGameObject) 
        {
            PosNumber += 1;
        }
    }

    public void MoveTarget() 
    {
        if (PosNumber == 0)
        {
            TargetGameObject.transform.position = P1.transform.position;
        }

        if (PosNumber == 1) 
        {
            TargetGameObject.transform.position = P2.transform.position;
        }

        if (PosNumber == 2)
        {
            TargetGameObject.transform.position = P3.transform.position;
        }

        if(PosNumber == 3) 
        {
            PosNumber = 0;
        }

        if (PosNumber == 4) 
        {
            TargetGameObject.transform.position = RoomPt.transform.position;
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet")) 
        {
            shot = true;
            PosNumber = 4;
            agent.speed = MinSpeed;
            Destroy(other.gameObject);
            
        }
    }
}
