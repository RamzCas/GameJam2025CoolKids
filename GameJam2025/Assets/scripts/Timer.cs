using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float TimeRemanding;

    void Update()
    {
        TimeRemanding -= Time.deltaTime;
        int mintues = Mathf.FloorToInt(TimeRemanding / 60);
        int seconds = Mathf.FloorToInt(TimeRemanding % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", mintues, seconds);
    }
}
