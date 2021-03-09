using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUI3DRoot : MBSingleton<TUI3DRoot>
{
    public Camera UICamera;
    public Canvas UICanvas;

    public void AddChild(GameObject obj)
    {
        obj.transform.SetParent(this.UICanvas.transform, false);
    }

    public GameObject AddChild(string assetPath)
    {
        Object obj = Resources.Load(assetPath);
        GameObject ui = GameObject.Instantiate(obj) as GameObject;
        this.AddChild(ui);
        return ui;
    }

    public void Clear()
    {
        for (int i = 0; i < this.UICanvas.transform.childCount; i++)
        {
            GameObject.Destroy(this.UICanvas.transform.GetChild(i).gameObject);
        }
    }
}
