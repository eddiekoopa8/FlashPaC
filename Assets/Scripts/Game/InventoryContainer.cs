using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer
{
    public Inventory.Type containerType;

    List<InventoryItem> items;

    public InventoryContainer(Inventory.Type type)
    {
        containerType = type;
        items = new List<InventoryItem>();
    }

    public int Count { get { return items.Count; } }

    public void add(InventoryItem item)
    {
        Debug.Log("added \n" + containerType);
        items.Add(item);
    }
}
