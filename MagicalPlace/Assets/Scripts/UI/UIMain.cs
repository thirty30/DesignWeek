using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : TUIBasePage
{
    public List<Slider> SliderAttributs;
    public Text TextSoupCount;

    public override void OnInitialize(params object[] parms)
    {
        for (int i = 0; i < this.SliderAttributs.Count; i++)
        {
            this.SliderAttributs[i].value = 1;
        }
    }

    public override void OnUpdate()
    {
        float[] Attr = Player.GetSingleton().Attributes;
        for (int i = 0; i < Attr.Length; i++)
        {
            this.SliderAttributs[i].value = Attr[i];
        }
        this.TextSoupCount.text = "x" + Player.GetSingleton().SoupCount.ToString();
    }
}
