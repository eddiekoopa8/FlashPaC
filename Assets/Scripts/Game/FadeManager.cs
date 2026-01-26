using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    static string InstName = "FadeBlock";
    SpriteRenderer renderer = null;
    public bool FadeInStart = true;
    bool fadeIn = false;
    bool fadeOut = false;

    float currentAlpha = 0.0f;
    float currentSpeed = 1f;

    public void FadeIn(float speed)
    {
        currentSpeed = speed;
        fadeIn = true;
        fadeOut = false;
        setAlpha(255);
    }
    public void FadeOut(float speed)
    {
        currentSpeed = speed;
        fadeOut = true;
        fadeIn = false;
        setAlpha(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(gameObject.name == InstName, "ERR: FadeManager object should be named FadeBlock.");
        renderer = GetComponent<SpriteRenderer>();
        Debug.Assert(renderer != null);
        setAlpha(0);
        if (FadeInStart)
        {
            FadeIn(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if (currentAlpha > 0)
            {
                setAlpha(currentAlpha - currentSpeed);
            }
            else
            {
                setAlpha(0);
            }
        }
        else if (fadeOut)
        {
            if (currentAlpha < 255)
            {
                setAlpha(currentAlpha + currentSpeed);
            }
            else
            {
                setAlpha(255);
            }
        }
    }

    void setAlpha(float a)
    {
        if (currentAlpha == a) return;
        if (currentAlpha > 255)
        {
            currentAlpha = 255;
        }
        if (currentAlpha < 0)
        {
            currentAlpha = 255;
        }
        currentAlpha = a;
        Color tmp = renderer.color;
        tmp.a = (currentAlpha / 255);
        renderer.color = tmp;
    }

    void setAlpha(int a)
    {
        setAlpha((float)a);
    }

    public static FadeManager GetInstance()
    {
        return GameObject.Find(InstName).GetComponent<FadeManager>();
    }
}
