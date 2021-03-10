using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MBSingleton<Main>
{
    // Start is called before the first frame update
    void Start()
    {
        Player.GetSingleton().Init();

        this.InitUI();
        TUIManager.GetSingleton().OpenUI("UIMain");

        AudioManager.GetSingleton().Init();
    }

    // Update is called once per frame
    void Update()
    {
        TUIManager.GetSingleton().UpdateUI();
    }

    private void InitUI()
    {
        TUIManager.GetSingleton().Initialize();
        TUIManager.GetSingleton().RegisterUI("UI/", "UIMain");
        TUIManager.GetSingleton().RegisterUI("UI/", "UIPopTips");
    }
}
