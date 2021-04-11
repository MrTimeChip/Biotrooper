using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public bool canDealDamage => _canDealDamage;
    private bool _canDealDamage;
    private int _damageAmount;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Damageable")) return;
        if (!canDealDamage) return;
        var damageable = other.gameObject.GetComponent<IDamageable>();
        damageable.Damage(_damageAmount);
    }

    public void Damage(int damageAmount)
    {
        _canDealDamage = true;
        _damageAmount = damageAmount;
    }

    public void OnDamageEnd()
    {
        _canDealDamage = false;
    }
}
