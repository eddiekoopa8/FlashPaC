using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Fade : MonoBehaviour
{
    static string InstName = "FadeBlock";
    new SpriteRenderer renderer;
    public bool FadeInOnStart = true;
    public float FadeInOnStartSpeed = 2;
    bool fadingIn = false;
    bool fadingOut = false;

    float currentAlpha = 0.0f;
    float currentSpeed = 1f;

    void fadeIn(float speed = 2)
    {
        currentSpeed = speed;
        fadingIn = true;
        fadingOut = false;
        setAlpha(255);
    }

    void fadeOut(float speed = 2)
    {
        currentSpeed = speed;
        fadingOut = true;
        fadingIn = false;
        setAlpha(0);
    }

    bool isBusy()
    {
        return fadingIn || fadingOut;
    }

    bool isIn()
    {
        return !isBusy() && !fadingIn && currentAlpha == 0;
    }

    bool isOut()
    {
        return !isBusy() && !fadingOut && currentAlpha == 255;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(gameObject.name == InstName, "ERR: Fade object should be named \"" + InstName + "\".");
        renderer = GetComponent<SpriteRenderer>();
        Debug.Assert(renderer != null);
        setAlpha(0);
        if (FadeInOnStart)
        {
            fadeIn(FadeInOnStartSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingIn)
        {
            if (currentAlpha >= 0)
            {
                setAlpha(currentAlpha - currentSpeed);
            }
            else
            {
                setAlpha(0);
                fadingIn = false;
            }
        }
        else if (fadingOut)
        {
            if (currentAlpha <= 255)
            {
                setAlpha(currentAlpha + currentSpeed);
            }
            else
            {
                setAlpha(255);
                fadingOut = false;
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
        if (renderer != null)
        {
            Color tmp = renderer.color;
            tmp.a = (currentAlpha / 255);
            renderer.color = tmp;
        }
    }

    void setAlpha(int a)
    {
        setAlpha((float)a);
    }

    static Fade getInst()
    {
        return GameObject.Find(InstName).GetComponent<Fade>();
    }

    public static void In(float speed = 2f)
    {
        getInst().fadeIn(speed);
    }

    public static void Out(float speed = 2f)
    {
        getInst().fadeOut(speed);
    }

    public static bool IsBusy()
    {
        return getInst().isBusy();
    }

    public static bool IsIn()
    {
        return getInst().isIn();
    }

    public static bool IsOut()
    {
        return getInst().isOut();
    }
}