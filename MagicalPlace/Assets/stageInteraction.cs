using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageInteraction : MonoBehaviour
{
    public int furnitureID;
    public float rechargeValue;
    public Sprite deathSprite;


    public void RechargeMeter()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().RechargeMeter(furnitureID, rechargeValue);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().UpdateMeterValues();
    }

    public void InteractionDeath()
    {
        GetComponent<SpriteRenderer>().sprite = deathSprite;
        gameObject.tag = "Untagged";
    }
}
