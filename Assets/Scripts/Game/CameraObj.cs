using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class CameraObj : MonoBehaviour
{
    static string InstName = "RootCamera";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(gameObject.name == InstName, "ERR: Camera object should be named \"" + InstName + "\".");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPos_(Vector2 pos)
    {
        Vector3 newp = new Vector3(pos.x, pos.y, -100);
        while (transform.position != newp)
        {
            transform.position = newp;
        }
    }

    public static GameObject GetObject()
    {
        return GameObject.Find(InstName);
    }

    static CameraObj getInst()
    {
        return GetObject().GetComponent<CameraObj>();
    }

    public static void SetPos(Vector2 pos)
    {
        getInst().SetPos_(pos);
    }
}
