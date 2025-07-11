using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViagraPill : MonoBehaviour
{
    [Header("General")]
    public FirstPersonControls firstPersonControls;
    public CharacterController characterController;
    public bool isEffected = false;
    public float effectTime = 10f;
    public GameObject Pill;

    [Header("Other Scripts")]
    public Timer timer;

    [Header("Timer")]
    public float ViagraTimer;

    void Update()
    {
        if (Pill.activeSelf == false) 
        {
            isEffected = true;
            //timer.TimeRemanding += 30;
            characterController.height = firstPersonControls.crouchHeight;
            firstPersonControls.isCrouching = true;
        }

        if(isEffected == true) 
        {
            ViagraTimer += Time.deltaTime;
        }

        if(ViagraTimer > effectTime) 
        {
            characterController.height = firstPersonControls.standingHeight;
            firstPersonControls.isCrouching = false;
            isEffected = false;
            ViagraTimer = 0;
            Destroy(this.gameObject);
        }
    }
}
