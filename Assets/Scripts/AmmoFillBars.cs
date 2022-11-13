using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoFillBars : MonoBehaviour
{
    public Image redFlame;
    public Image greenFlame;
    public Image blueFlame;

    private float redFill;
    private float greenFill;
    private float blueFill;

    private void Awake()
    {
        Events.OnAddResources += AddFill;
        Events.OnUseResources += UseFill;
        Events.OnSetResources += SetFill;

        redFill = 100;
        greenFill = 100;
        blueFill = 100;
    }

    private void OnDestroy()
    {
        Events.OnAddResources -= AddFill;
        Events.OnUseResources -= UseFill;
        Events.OnSetResources -= SetFill;
    }

    public void SetFill(int red, int green, int blue)
    {
        print("Set resources: " + red + ", " + green + ", " + blue);
        redFill = red;
        greenFill = green;
        blueFill = blue;

        ChangeFill();
    }

    public void AddFill(int red, int green, int blue)
    {
        print("Added resources: " + red + ", " + green + ", " + blue);
        redFill += red;
        greenFill += green;
        blueFill += blue;
        ChangeFill();
    }

    public void UseFill(int red, int green, int blue)
    {
        print("Used resources: " + red + ", " + green + ", " + blue);
        redFill -= red;
        greenFill -= green;
        blueFill -= blue;
        ChangeFill();
    }

    public void ChangeFill()
    {
        print("Changed fill bar amounts: " + redFill + ", " + greenFill + ", " + blueFill);
        redFlame.fillAmount = /*Random.Range(0, 1);*/redFill / 100;
        greenFlame.fillAmount = greenFill / 100;
        blueFlame.fillAmount = blueFill / 100;
    } 

}
