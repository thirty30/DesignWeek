using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageInteraction : MonoBehaviour
{
    public int furnitureID;
    public float rechargeValue;


    public void RechargeMeter()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().RechargeMeter(furnitureID, rechargeValue);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().UpdateMeterValues();
    }
}
