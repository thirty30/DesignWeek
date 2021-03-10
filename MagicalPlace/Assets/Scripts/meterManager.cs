using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meterManager : MonoBehaviour
{
    public float soupInventory;
    public float meterDecreaseSpeed;

    public float meter1Value;
    public float meter2Value;
    public float meter3Value;

    void Start()
    {

    }

    void Update()
    {
        GlobalEvent.Dispatch(CommonDefine.UIMAIN_POWER_BAR, 1, -meterDecreaseSpeed*Time.deltaTime);
    }
}
