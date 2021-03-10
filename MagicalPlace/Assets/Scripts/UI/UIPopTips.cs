using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopTips : TUIBasePage
{
    public Text TextContent;
    public GameObject TextNode;

    private float mCurTime;

    public override void OnInitialize(params object[] parms)
    {
        this.TextContent.text = (string)parms[0];
        IEnumerator TimeHide()
        {
            yield return new WaitForSeconds(0.5f);
            float y = 0;
            for (int i = 0; i < 30; i++)
            {
                y += 0.1f * Time.deltaTime;
                this.TextNode.transform.position += new Vector3(0, y, 0);
                yield return 0;
            }
            TUIManager.GetSingleton().CloseUI(this);
        }
        StartCoroutine(TimeHide());
    }
}
