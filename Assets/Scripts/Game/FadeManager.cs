using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    static string InstName = "FadeBlock";
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(gameObject.name != InstName, "ERR: FadeManager object should be named FadeBlock.");
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static FadeManager GetInstance()
    {
        return GameObject.Find(InstName).GetComponent<FadeManager>();
    }
}
