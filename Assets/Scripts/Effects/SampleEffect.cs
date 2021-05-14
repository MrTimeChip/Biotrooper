using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEffect : Effect
{
    // Start is called before the first frame update
    public override void ApplyEffect()
    {
        Debug.Log("Effect is intact");
    }

    public override void EraseEffect()
    {
        Debug.Log("Effect is gone");
    }
}
