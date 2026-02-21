using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    public enum Type
    {
        Dummy = 0,
        Apple,
        Pencil,
        Max
    };

    public static string[] TypeDescriptions = {
        "???",
        "Apple",
        "Pencil",
        "???",
    };

    static int MAX_TYPE = (int)Type.Max;

    // Start is called before the first frame update
    bool active = false;
    bool changeAnim = false;

    static string InstName = "Inventory";

    Vector3 activePos;
    Vector3 inactivePos;

    List<InventoryContainer> containers;

    void Start()
    {
        containers = new List<InventoryContainer>();
        activePos = new Vector3(0, 0, 0);
        inactivePos = new Vector3(0, -350, 0);
        if (active)
        {
            transform.localPosition = activePos;
        }
        else
        {
            transform.localPosition = inactivePos;
        }

        for (int i = 0; i < MAX_TYPE; i++)
        {
            containers.Add(new InventoryContainer((Type)i));
        }
    }
    
    void setActive(bool flag)
    {
        active = flag;
        changeAnim = true;
        MenuOverlay.SetActive(flag);
    }

    bool isActive()
    {
        return active;
    }
    
    bool canDo()
    {
        return !PauseScreen.IsActive();
    }

    bool add(InventoryItem item)
    {
        for (int i = 0; i < MAX_TYPE; i++)
        {
            if (containers[i].containerType == item.InventoryType)
            {
                containers[i].add(item);
            }
        }

        RefreshText();

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (changeAnim)
        {
            if (active)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, activePos, 0.2f);
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, inactivePos, 0.2f);
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && canDo())
        {
            setActive(!active);
        }

        // For now on, the rest of the code needs the inventory to be active

        if (!active)
        {
            return;
        }
    }

    static Inventory getInst()
    {
        return GameObject.Find(InstName).GetComponent<Inventory>();
    }

    public static void SetActive(bool flag)
    {
        getInst().setActive(flag);
    }

    public static void Activate()
    {
        SetActive(true);
    }

    public static void Deactivate()
    {
        SetActive(false);
    }

    public static bool IsActive()
    {
        return getInst().isActive();
    }

    public void RefreshText()
    {
        GameObject.Find("InventInfo").GetComponent<TMP_Text>().text = " " + containers[1].Count + " apples.";
    }

    public static bool Add(InventoryItem item)
    {
        return getInst().add(item);
    }
}
