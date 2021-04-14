using UnityEngine;

public interface IWeapon
{
    void Attack();
    void SetItem(Item item);
    void SetPlayer(GameObject player);
    void OnAttackEnded();
}
