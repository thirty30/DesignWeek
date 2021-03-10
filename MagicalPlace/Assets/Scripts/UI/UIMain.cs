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

        GlobalEvent.Add(CommonDefine.UIMAIN_POWER_BAR, this.ModifyValueOfSlider);
    }

    public override void OnDestroy()
    {
        GlobalEvent.RemoveEvent(CommonDefine.UIMAIN_POWER_BAR);
    }

    private void ModifyValueOfSlider(params object[] parms)
    {
        int idx = (int)parms[0];
        float offset = (float)parms[1];

        if (idx == 1)
        {
            this.Slider1.value += offset;
        }
        else if (idx == 2)
        {
            this.Slider2.value += offset;
        }
        else if (idx == 1)
        {
            this.Slider2.value += offset;
        }
    }
}
