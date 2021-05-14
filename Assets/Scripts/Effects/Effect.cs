using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Effect : MonoBehaviour
{
    public string effectName => "Sample name";
    protected int assignedNumber;
    protected EffectManager effectManager;
    protected GameObject affected;

    public void SetEffectManager(EffectManager effectManager)
    {
        this.effectManager = effectManager;
    }

    public void SetAssignedNumber(int number)
    {
        assignedNumber = number;
    }

    public void SetAffected(GameObject affected)
    {
        this.affected = affected;
    }

    public virtual void ApplyEffect()
    {
        
    }

    public virtual void EraseEffect()
    {
        
    }
}
