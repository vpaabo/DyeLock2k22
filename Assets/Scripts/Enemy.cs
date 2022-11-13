using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int healthRed = 100;
    public int healthGreen = 100;
    public int healthBlue = 100;

    public int worthRed = 0;
    public int worthGreen = 0;
    public int worthBlue = 0;

    public int damageRed = 10;
    public int damageGreen = 10;
    public int damageBlue = 10;

    public abstract void takeDamage(int red, int green, int blue);
}
