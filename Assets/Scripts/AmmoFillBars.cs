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

        redFill = 1;
        greenFill = 1;
        blueFill = 1;
    }

    private void OnDestroy()
    {
        Events.OnAddResources -= AddFill;
        Events.OnUseResources -= UseFill;
        Events.OnSetResources -= SetFill;
    }

    public void SetFill(int red, int green, int blue)
    {
        redFill = red;
        greenFill = green;
        blueFill = blue;

        ChangeFill();
    }

    public void AddFill(int red, int green, int blue)
    {
        redFill += red;
        greenFill += green;
        blueFill += blue;
    }

    public void UseFill(int red, int green, int blue)
    {
        redFill -= red;
        greenFill -= green;
        blueFill -= blue;
    }

    public void ChangeFill()
    {
        print("changed fill bar amounts: " + redFill + ", " + greenFill + ", " + blueFill);
        redFlame.fillAmount = redFill / 100;
        greenFlame.fillAmount = greenFill / 100;
        blueFlame.fillAmount = blueFill / 100;
    } 

}
