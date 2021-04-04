using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public IWeapon currentWeapon;

    private void Start()
    {
        currentWeapon = gameObject.AddComponent<Weapon_Hand>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            currentWeapon.Attack();
        }
    }
}
