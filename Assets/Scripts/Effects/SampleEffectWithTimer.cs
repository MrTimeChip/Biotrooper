using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEffectWithTimer : Effect
{
    float currCountdownValue = 10;
    public IEnumerator StartCountdown(float countdownValue)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        if(currCountdownValue <= 0)
            Debug.Log("Timer is dead");
    }
    public override void ApplyEffect()
    {
        Debug.Log("Effect is intact");
        Debug.Log("Starting timer...");
        StartCoroutine(StartCountdown(currCountdownValue));
    }

    public override void EraseEffect()
    {
        Debug.Log("Effect is gone");
    }
}
