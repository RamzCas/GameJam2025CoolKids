using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFlicker : MonoBehaviour
{
    public Light[] lights;
    public float minInterval = 15f;
    public float maxInterval = 30f;

    public Timer timer; // Reference to your timer script

    private bool lightsOn = true;

    void Start()
    {
        StartCoroutine(FlickerCoroutine());
    }

    private IEnumerator FlickerCoroutine()
    {
        while (timer.TimeRemanding > 0f)
        {
            lightsOn = !lightsOn;

            foreach (Light light in lights)
                light.enabled = lightsOn;

            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);
        }

        // When time runs out, maybe leave the lights ON or OFF
        foreach (Light light in lights)
            light.enabled = false;
    }

}
