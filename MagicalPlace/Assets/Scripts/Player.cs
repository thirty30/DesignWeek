using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CSingleton<Player>
{
    public float[] Attributes;
    public int SoupCount;

    public void Init()
    {
        this.Attributes = new float[4] { 1, 1, 1, 1 };
        this.SoupCount = 0;
    }
}
