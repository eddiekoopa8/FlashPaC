using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    // Start is called before the first frame update

    static string InstName = "Tooltip";

    void Start()
    {
        Debug.Assert(gameObject.name == InstName, "Tooltip should be called " + InstName);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().enabled = !MenuOverlay.IsActive();
    }

    void set(string text)
    {
        GetComponent<TMP_Text>().text = text;
    }

    static Tooltip getInst()
    {
        return GameObject.Find(InstName).GetComponent<Tooltip>();
    }

    public static void Set(string text)
    {
        getInst().set(text);
    }

    public static void Clear()
    {
        getInst().set("");
    }
}
