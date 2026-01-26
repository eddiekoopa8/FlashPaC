using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowButton : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer renderer;
    bool doAction = true;
    public Transform TargetPoint;
    int speedf = 17;

    void Start()
    {
        OnMouseDown();
        renderer = GetComponent<SpriteRenderer>();
        Debug.Assert(TargetPoint != null, "PLEASE set TargetPoint!!!");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (doAction && Fade.IsOut())
        {
            // hack
            CameraObj.SetPos(TargetPoint.position);
            Fade.In(speedf);
            doAction = false;
        }*/
    }

    public void OnMouseDown()
    {
        if (Fade.IsIn())
        {
            Debug.Log("goto " + TargetPoint.name);
            Fade.In(speedf);
            CameraObj.SetPos(TargetPoint.position);
            doAction = true;
        }
    }
}
