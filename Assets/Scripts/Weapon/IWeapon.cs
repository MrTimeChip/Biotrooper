public interface IWeapon
{
    void Attack();
    WeaponType WeaponType { get; }
    string WeaponName { get; }
}
