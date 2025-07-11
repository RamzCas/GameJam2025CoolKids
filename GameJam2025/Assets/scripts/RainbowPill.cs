using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowPill : MonoBehaviour
{
    public GameObject Rainbow;
    //public SideEffects SideEffects;

    [Header("General")]
    public FirstPersonControls firstPersonControls;
    public CharacterController characterController;
    public bool isEffected = false;
    public float effectTime = 10f;

    [Header("Rainbow Settings")]
    public GameObject rainbowCanvas;
    public Animator rainbowAnim;

    [Header("Timer")]
    public float RainbowTimer;

    [Header("Other Scripts")]
    public Timer timer;
    //public RainbowPill rainbowPill;
    private void Update()
    {
        if (Rainbow.activeSelf == false) 
        {
            Debug.Log("Rainbow Effects on");
            isEffected = true;
            timer.TimeRemanding += 30;
            rainbowCanvas.SetActive(true);
            rainbowAnim.enabled = true;
        }

        if (isEffected == true) 
        {
            RainbowTimer += Time.deltaTime;
        }

        if(RainbowTimer >= 10) 
        {
            isEffected = false;
            RainbowTimer = 0;
            rainbowAnim.enabled = false;
            rainbowCanvas.SetActive(false);
            //rainbowPill.enabled = false;
            Destroy(this.gameObject);
        }
    }
}
