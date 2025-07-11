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

    [Header("Flicker Settings")]
    [Space(5)]
    public Light[] lights;
    //public float flickerDuration = 5f; // total time in seconds
    public float flickerInterval = 0.2f; // time between flickers

    [Header("Camera Settings")]
    [Space(5)]
    public Animator mainCamAnim;

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
        characterController.height = firstPersonControls.crouchHeight;
        firstPersonControls.isCrouching = true;
        StartCoroutine(WaitToNormal());
    }

    public void RainbowEffects()
    {
        //Debug.Log("Rainbow");
        StartCoroutine(FlickerLights());
    }
    private IEnumerator FlickerLights()
    {
        float timer = 0f;

        while (timer < effectTime)
        {
            foreach (Light light in lights)
            {
                light.color = Random.ColorHSV();
                // Optional: random intensity too
                light.intensity = Random.Range(0.5f, 2f);
            }

            yield return new WaitForSeconds(flickerInterval);
            timer += flickerInterval;
        }

        if (timer >= effectTime)
        { MakeLightsNormal(); }

    }

    public void DizzyEffects()
    {
        //Debug.Log("Dizzy");
        mainCamAnim.enabled= true;
        StartCoroutine(WaitToNormal());
    }

    public IEnumerator WaitToNormal()
    {
        yield return new WaitForSeconds(effectTime);
        isEffected = false;

        MakeHeightNormal();
        MakeCamNormal();
    }

    private void MakeHeightNormal()
    {
        characterController.height = firstPersonControls.standingHeight;
        firstPersonControls.isCrouching = false;
    }

    private void MakeLightsNormal()
    {
        //
        //make light white again? change intensity back?
    }

    private void MakeCamNormal()
    {
        //
        mainCamAnim.enabled = false;
    }
 }
