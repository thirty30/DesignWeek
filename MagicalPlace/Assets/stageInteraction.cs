using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageInteraction : MonoBehaviour
{
    public int furnitureID;
    public float rechargeValue;
    public Sprite deathSprite;
    public Sprite happy;
    public Sprite hungry;
    public Sprite starving;


    public void RechargeMeter()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().RechargeMeter(furnitureID, rechargeValue);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().UpdateMeterValues();
    }

    public void InteractionDeath()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = deathSprite;
        gameObject.tag = "Untagged";
    }

    public void ChangeExpression(float status)
    {
        foreach (Transform child in transform)
        {
            if (status > 0.6)
                child.GetComponent<SpriteRenderer>().sprite = happy;
            else if (status <= 0.6 && status >= 0.3)
                child.GetComponent<SpriteRenderer>().sprite = hungry;
            else
                child.GetComponent<SpriteRenderer>().sprite = starving;
        }
    }

}
