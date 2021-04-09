using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Hand : MonoBehaviour, IWeapon
{
    public WeaponType WeaponType => WeaponType.Melee;
    public string WeaponName => "Hand";
    public float WeaponRadius => 0.5f;
    public int WeaponDamage => 1;

    public void OnAttackEnded()
    {
        _damageDealer.canDealDamage = false;
    }

    private Animator _anim;
    private DamageDealer _damageDealer;
    
    public void Start()
    {
        _anim = GetComponentInParent<Animator>();
        _damageDealer = transform.Find("AttackPoint").GetComponent<DamageDealer>();
    }
    
    public void Attack()
    {
        _damageDealer.canDealDamage = true;
        _anim.SetBool("AttackMelee", true);
    }
}
