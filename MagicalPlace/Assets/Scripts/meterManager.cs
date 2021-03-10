using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meterManager : MonoBehaviour
{
    public int soupInventory;
    public float meterDecreaseSpeed;


    public List<float> meterValues = new List<float>();

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            meterValues.Add(1);
        }
    }

    private void Start()
    {
        UpdateSoup();
    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            meterValues[i] -= meterDecreaseSpeed * Time.deltaTime;
        }

        UpdateMeterValues();
    }


    public void UpdateMeterValues()
    {
        //update displayed value for each meter
        for (int i = 0; i<4; i++)
        {
            Player.GetSingleton().Attributes[i] = meterValues[i];
        }
    }

    public void RechargeMeter(int id, float rechargeValue)
    {
        if (meterValues[id] + rechargeValue > 1)
            meterValues[id] = 1;
        else
            meterValues[id] += rechargeValue;
    }

    public void UpdateSoup()
    {
        Player.GetSingleton().SoupCount = soupInventory;
    }
}
