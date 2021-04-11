using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject prefab;
    private IWeapon _currentWeapon;
    private GameObject _instance;

    private void Start()
    {
        var go = transform.Find("ArmLeft").gameObject;
        _instance = Instantiate(prefab, go.transform.position, go.transform.rotation, go.transform);
        _currentWeapon = _instance.GetComponent<IWeapon>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _currentWeapon.Attack();
        }
    }

    public void OnAttackEnded()
    {
        _currentWeapon.OnAttackEnded();
    }
    
}
