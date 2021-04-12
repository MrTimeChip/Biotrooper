using UnityEngine;

public interface IWeapon
{
    void Attack();
    void SetItem(Item item);
    void OnAttackEnded();
}
