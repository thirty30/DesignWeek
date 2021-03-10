using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : TUIBasePage
{
    public Slider Slider1;
    public Slider Slider2;
    public Slider Slider3;

    public override void OnInitialize(params object[] parms)
    {
        this.Slider1.value = 1;
        this.Slider2.value = 1;
        this.Slider3.value = 1;
    }
}
