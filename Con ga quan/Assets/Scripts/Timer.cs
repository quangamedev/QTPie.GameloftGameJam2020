using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int startTimer = 50;
    public TextMeshProUGUI timerText;
    public void StartTimer()
    {
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        while(startTimer > 0)
        {
            startTimer--;
            timerText.text = "Time to inspect: " + startTimer;
            yield return new WaitForSeconds(1f);
        }
    }
}
