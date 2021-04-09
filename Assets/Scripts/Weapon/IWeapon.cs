using UnityEngine;

public interface IWeapon
{
    void Attack();
    WeaponType WeaponType { get; }
    string WeaponName { get; }
    float WeaponRadius { get; }
    int WeaponDamage { get; }
    void OnAttackEnded();
}
