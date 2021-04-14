using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour, IDamageable
{
    public void Damage(int amount)
    {
        Destroy(transform.parent.gameObject);
    }
}
