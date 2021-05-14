using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private Inventory _inventory;
    private GameObject _affected;
    public List<Effect> effects;

    public void Start()
    {
        _affected = gameObject;
        effects = new List<Effect>();
    }

    public void SetInventory(Inventory inv)
    {
        _inventory = inv;
    }

    public int AddEffect(Effect effect)
    {
        effect.SetAffected(_affected);
        effect.SetEffectManager(GetComponent<EffectManager>());
        effects.Add(effect);
        var number = effects.Count - 1;
        effect.SetAssignedNumber(number);
        effect.ApplyEffect();
        return number;
    }

    public void RemoveEffect(int number)
    {
        if (effects.Count - 1 < number)
            throw new ArgumentException($"No such effect number! {number}");
        var removing = effects[number];
        removing.EraseEffect();
        effects.RemoveAt(number);
    }
}
