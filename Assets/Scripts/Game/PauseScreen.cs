using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseScreen : MonoBehaviour
{
    // Start is called before the first frame update
    bool active = false;
    bool changeAnim = false;

    static string InstName = "PauseScreen";

    Vector3 activePos;
    Vector3 inactivePos;

    void Start()
    {
        activePos = new Vector3(0, 0, 0);
        inactivePos = new Vector3(0, 350, 0);
        if (active)
        {
            transform.localPosition = activePos;
        }
        else
        {
            transform.localPosition = inactivePos;
        }
    }
    
    void setActive(bool flag)
    {
        active = flag;
        changeAnim = true;
        MenuOverlay.SetActive(flag);
        if (active)
        {
            //Fade.Out(3);
        }
        else
        {
            //Fade.In(3);
        }
    }

    bool isActive()
    {
        return active;
    }
    
    bool canDo()
    {
        return !Inventory.IsActive();
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

        if (Input.GetKeyDown(KeyCode.P) && canDo())
        {
            setActive(!active);
        }

        // For now on, the rest of the code needs the inventory to be active

        if (!active)
        {
            return;
        }
    }

    static PauseScreen getInst()
    {
        return GameObject.Find(InstName).GetComponent<PauseScreen>();
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
}
