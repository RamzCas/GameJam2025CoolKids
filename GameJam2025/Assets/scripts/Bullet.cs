using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }

   /* private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }*/
}
