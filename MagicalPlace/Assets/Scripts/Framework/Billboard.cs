using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public enum BillBoardType
    {
        Free,
        LockYAxis,
    }

    public BillBoardType Type;

    private void Update()
    {
        var rMainCamera = TUI3DRoot.GetSingleton().UICamera;
        if (rMainCamera == null) return;

        if (this.Type == BillBoardType.Free)
        {
            this.gameObject.transform.LookAt(rMainCamera.transform, rMainCamera.transform.up);
        }
        else if (this.Type == BillBoardType.LockYAxis)
        {
            this.gameObject.transform.LookAt(rMainCamera.transform, Vector3.up);
        }
    }
}