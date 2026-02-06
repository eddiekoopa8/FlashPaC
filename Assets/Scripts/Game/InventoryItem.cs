using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory.Type InventoryType = new Inventory.Type();

    void Start()
    {
        Debug.Assert(InventoryType != Inventory.Type.Dummy);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (MenuOverlay.IsActive()) return;
        Inventory.Add(this);
        Destroy(gameObject);
        OnMouseExit();
    }

    public void OnMouseEnter()
    {
        if (MenuOverlay.IsActive()) return;
        Tooltip.Set(Inventory.TypeDescriptions[(int)InventoryType] + " collectable.");
    }

    public void OnMouseExit()
    {
        Tooltip.Clear();
    }
}
