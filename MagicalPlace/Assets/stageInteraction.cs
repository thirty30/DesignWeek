using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageInteraction : MonoBehaviour
{
    public int furnitureID;
    public float rechargeValue;


    public void RechargeMeter()
    {
        GlobalEvent.Dispatch(CommonDefine.UIMAIN_POWER_BAR, furnitureID, rechargeValue);
    }
}
