using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.InitUI();
    }

    // Update is called once per frame
    void Update()
    {
        TUIManager.GetSingleton().UpdateUI();
    }

    private void InitUI()
    {
        TUIManager.GetSingleton().Initialize();
    }
}
