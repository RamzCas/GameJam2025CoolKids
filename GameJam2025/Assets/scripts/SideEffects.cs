using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideEffects : MonoBehaviour
{
    public int EffectID = 0;
    public FirstPersonControls firstPersonControls;
    public CharacterController characterController;
    public bool isEffected = false;

   

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
        Debug.Log("Viagra");
        characterController.height = firstPersonControls.crouchHeight;
        firstPersonControls.isCrouching = true;
        StartCoroutine(WaitToNormal());
    }

    public void RainbowEffects()
    {
        Debug.Log("Rainbow");
    }

    public void DizzyEffects()
    {
        Debug.Log("Dizzy");
    }

    public IEnumerator WaitToNormal()
    {
        yield return new WaitForSeconds(10f);
        isEffected = false;

        //viagra
        characterController.height = firstPersonControls.standingHeight;
        firstPersonControls.isCrouching = false;

    }
}
