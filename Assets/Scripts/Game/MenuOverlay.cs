using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOverlay
{
    static bool active = false;

    public static void SetActive(bool flag)
    {
        active = flag;
    }

    public static bool IsActive()
    {
        return active;
    }
}
