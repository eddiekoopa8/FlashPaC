using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    GameObject clicked = null;

    void Start()
    {
        Debug.Log("mouse manage start");

        clicked = null;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name != null && Input.GetMouseButtonDown(0))
            {
                clicked = hit.collider.gameObject;
                Debug.Log("Clicked \"" + clicked.name + "\".");
            }
        }
    }

    public GameObject GetClickedObject()
    {
        return clicked;
    }
}
