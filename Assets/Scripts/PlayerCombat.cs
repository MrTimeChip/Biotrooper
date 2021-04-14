using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private IWeapon _currentWeapon;
    private GameObject _instance;

    private Inventory inventory;

    public void SetInventory(Inventory inv)
    {
        this.inventory = inv;

        inventory.OnPartUpdated += Inventory_OnPartUpdated;
        Inventory_OnPartUpdated(null, null);
    }

    private void Inventory_OnPartUpdated(object sender, System.EventArgs a)
    {
        var go = transform.Find("ArmLeft").gameObject;

        if (inventory.armLeft != null && inventory.armLeft.itemDescriptor.prefab != null)
        {
            var prefab = inventory.armLeft.itemDescriptor.prefab;
            _instance = Instantiate(prefab, go.transform.position, go.transform.rotation, go.transform);
            _currentWeapon = _instance.GetComponent<IWeapon>();
            _currentWeapon.SetItem(inventory.armLeft);
            _currentWeapon.SetPlayer(transform.gameObject);
        }
        else
        {
            _instance = null;
            _currentWeapon = null;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !Inventory.isInventoryOpened)
        {
            if (_currentWeapon != null)
                _currentWeapon.Attack();
        }
    }

    public void OnAttackEnded()
    {
        if (_currentWeapon != null)
            _currentWeapon.OnAttackEnded();
    }
    
}
