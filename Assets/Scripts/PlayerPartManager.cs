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
        transform.Find("Body").GetComponent<SpriteRenderer>().sprite = inventory.body == null ? null : inventory.body.icon;
        transform.Find("ArmLeft").GetComponent<SpriteRenderer>().sprite = inventory.armLeft == null ? null : inventory.armLeft.icon;
        transform.Find("ArmRight").GetComponent<SpriteRenderer>().sprite = inventory.armRight == null ? null : inventory.armRight.icon;
        transform.Find("LegLeft").GetComponent<SpriteRenderer>().sprite = inventory.legLeft == null ? null : inventory.legLeft.icon;
        transform.Find("LegRight").GetComponent<SpriteRenderer>().sprite = inventory.legRight == null ? null : inventory.legRight.icon;
    }
}
