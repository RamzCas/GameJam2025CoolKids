using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyPill : MonoBehaviour
{
    [Header("General")]
    public bool isEffected = false;
    public float effectTime = 10f;
    public GameObject Pill;
    public GameObject penisparts;

    [Header("Camera Settings")]
    public Animator mainCamAnim;

    [Header("Other Scripts")]
    public Timer timer;

    [Header("Timer")]
    public float DizzyTimer;

    private void Update()
    {
       if (Pill.activeSelf == false) 
        {
            Debug.Log("Dizzy Effects on");
            isEffected = true;
            //timer.TimeRemanding += 30;
        }

       if( isEffected == true) 
        {
            DizzyTimer += Time.deltaTime;
            mainCamAnim.enabled = true;
            penisparts.SetActive(true);
        }

       if (DizzyTimer >= effectTime ) 
        {
            mainCamAnim.enabled = false;
            DizzyTimer = 0;
            isEffected = false; 
            penisparts.SetActive (false);
            Destroy(this.gameObject);
        }

    }
}
