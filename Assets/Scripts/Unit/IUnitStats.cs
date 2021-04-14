using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitStats
{

    public void TakeDamage(int damage);
    public void RestoreHealth(int health);
    public void Update();

    public bool IsDeath();
}
