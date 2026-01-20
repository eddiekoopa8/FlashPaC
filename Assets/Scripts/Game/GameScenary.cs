using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScenary : MonoBehaviour
{
    static string OBJ_PAN_POINT = "GS_PAN_POINT";

    List<GameObject> panObjs;

    // Start is called before the first frame update
    void Start()
    {
        panObjs = new List<GameObject>();

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("CameraPan"))
        {
            panObjs.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
