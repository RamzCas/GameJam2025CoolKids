using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideEffects : MonoBehaviour
{
    [Header("General")]
    [Space(5)]
    public int EffectID = 0;
    public FirstPersonControls firstPersonControls;
    public CharacterController characterController;
    public bool isEffected = false;
    public float effectTime = 10f;

    [Header("Rainbow Settings")]
    [Space(5)]
    public GameObject rainbowCanvas;
    public Animator rainbowAnim;

    [Header("Camera Settings")]
    [Space(5)]
    public Animator mainCamAnim;

    [Header("Other Scripts")]
    public Timer timer;

    [Header("Timer")]
    public float ViagraTimer;
    public float RainbowTimer;
    public float DizzyTimer;

    public void PickUpPill()
    {
        switch (EffectID)
        {
            case 1: ViagraEffects();
                break;
            case 2: RainbowEffects();
                break;
            case 3: DizzyEffects();
                break;
        }  
    }

    public void ViagraEffects()
    {
        //Debug.Log("Viagra");
        if (characterController != null && firstPersonControls != null)
        {
            timer.TimeRemanding += 30;
            characterController.height = firstPersonControls.crouchHeight;
            firstPersonControls.isCrouching = true;
            StartCoroutine(WaitToNormal());
        }
    }

    public void RainbowEffects()
    {
        Debug.Log("Rainbow");
        //if (rainbowCanvas != null && rainbowAnim != null)
        //{
            timer.TimeRemanding += 30;
            rainbowCanvas.SetActive(true);
            rainbowAnim.enabled = true;
            StartCoroutine(WaitToNormal());
            
       

       // }
       
    }
   

    public void DizzyEffects()
    {
        //Debug.Log("Dizzy");
        if (mainCamAnim != null)
        {
            timer.TimeRemanding += 30;
            mainCamAnim.enabled= true;
            StartCoroutine(WaitToNormal());
        }
        
    }

    public IEnumerator WaitToNormal()
    {
        Debug.Log("normal");
        yield return new WaitForSeconds(effectTime);
        isEffected = false;

        MakeHeightNormal();
        MakeCamNormal();
        MakeRainbowNormal();
    }

    private void MakeHeightNormal()
    {
        characterController.height = firstPersonControls.standingHeight;
        firstPersonControls.isCrouching = false;
    }

    private void MakeRainbowNormal()
    {
       /* rainbowAnim.enabled = false;
        rainbowCanvas.SetActive(false);*/
    }

    private void MakeCamNormal()
    {
        //
        mainCamAnim.enabled = false;
    }


    private void Update()
    {
        /*if (rainbowCanvas.activeSelf)
        {
            Debug.Log("Rainbow time");
            RainbowTimer += Time.deltaTime;
        }

        if (RainbowTimer >= 2)
        {
            rainbowAnim.enabled = false;
            rainbowCanvas.SetActive(false);
            RainbowTimer = 0;
        }*/
    }
}
