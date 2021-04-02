using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Hand : MonoBehaviour, IWeapon
{
    public WeaponType WeaponType => WeaponType.Melee;
    public string WeaponName => "Hand";
    private Animator _anim;
    private Collider2D attackBody;

    public void Start()
    {
        _anim = GetComponent<Animator>();
        var leftArm = transform.Find("ArmLeft").gameObject;
        attackBody = leftArm.GetComponent<Collider2D>();
    }
    
    public void Attack()
    {
        _anim.SetBool("AttackMelee", true);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(attackBody.transform.position, attackBody.bounds.size);
    }
}
