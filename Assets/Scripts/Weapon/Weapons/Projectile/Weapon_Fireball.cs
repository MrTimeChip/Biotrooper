using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Fireball : MonoBehaviour, IWeapon
{
    private Item item;
    private Animator _anim;

    public void Start()
    {
        _anim = GetComponentInParent<Animator>();
    }

    public void OnAttackEnded()
    {
    }

    public void Attack()
    {
        _anim.SetBool("AttackMelee", true);
        print("FIIIIIRE");
    }

    public void SetItem(Item item)
    {
        this.item = item;
    }
}
