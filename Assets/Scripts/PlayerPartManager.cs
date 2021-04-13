using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartManager : MonoBehaviour
{
    private Inventory inventory;

    public void SetInventory(Inventory inv)
    {
        this.inventory = inv;

        inventory.OnPartUpdated += Inventory_OnPartUpdated;
        Inventory_OnPartUpdated(null, null);
    }

    private void Inventory_OnPartUpdated(object sender, System.EventArgs a)
    {
        transform.Find("Body").GetComponent<SpriteRenderer>().sprite = inventory.body == null ? null : inventory.body.itemDescriptor.icon;
        transform.Find("ArmLeft").GetComponent<SpriteRenderer>().sprite = inventory.armLeft == null ? null : inventory.armLeft.itemDescriptor.icon;
        transform.Find("ArmRight").GetComponent<SpriteRenderer>().sprite = inventory.armRight == null ? null : inventory.armRight.itemDescriptor.icon;
        transform.Find("LegLeft").GetComponent<SpriteRenderer>().sprite = inventory.legLeft == null ? null : inventory.legLeft.itemDescriptor.icon;
        transform.Find("LegRight").GetComponent<SpriteRenderer>().sprite = inventory.legRight == null ? null : inventory.legRight.itemDescriptor.icon;
    }

    public bool HaveStrengthJump()
    {
        if (inventory.legLeft != null && inventory.legLeft.itemDescriptor.name == "LegStrengthJump")
        {
            return true;
        }
        if (inventory.legRight != null && inventory.legRight.itemDescriptor.name == "LegStrengthJump")
        {
            return true;
        }
        return false;
    }

    public bool HaveDash()
    {
        if (inventory.legLeft != null && inventory.legLeft.itemDescriptor.name == "LegDash")
        {
            return true;
        }
        if (inventory.legRight != null && inventory.legRight.itemDescriptor.name == "LegDash")
        {
            return true;
        }
        return false;
    }
}
