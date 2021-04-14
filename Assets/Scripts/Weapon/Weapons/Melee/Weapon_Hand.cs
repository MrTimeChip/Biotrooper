using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Hand : MonoBehaviour, IWeapon
{
    private GameObject player;
    private Item item;
    private Animator _anim;
    private DamageDealer _damageDealer;

    public void Start()
    {
        _anim = GetComponentInParent<Animator>();
        _damageDealer = transform.Find("AttackPoint").GetComponent<DamageDealer>();
    }

    public void OnAttackEnded()
    {
        _damageDealer.OnDamageEnd();
    }

    public void Attack()
    {
        _damageDealer.Damage(item.damage);
        _anim.SetBool("AttackMelee", true);
    }

    public void SetItem(Item item)
    {
        this.item = item;
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
