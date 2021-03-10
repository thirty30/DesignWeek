using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIHelper
{
    public static void ShowTips(string aText)
    {
        TUIManager.GetSingleton().OpenUI("UIPopTips", aText);
    }
}
