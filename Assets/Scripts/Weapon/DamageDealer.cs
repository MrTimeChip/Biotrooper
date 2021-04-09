using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public bool canDealDamage { get; set; }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Damagable"))
        {
            if (canDealDamage)
            {
                Debug.Log("I did damage!");
            }
        }
    }
}
