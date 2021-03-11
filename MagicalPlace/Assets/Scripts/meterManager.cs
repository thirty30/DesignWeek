using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meterManager : MonoBehaviour
{
    public int soupInventory;
    public float meterDecreaseSpeed;
    public float meterDecreaseAccel;

    public float gameTimerMax;
    public GameObject timerText;
    public GameObject endText;
    private float timer;
    private float timerSeconds;
    private int deaths;
    private bool gameActive = true;



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
        if (gameActive)
        {
            timer++;
            if (timer % 60 == 0)
            {
                timerSeconds++;
                TimerTextUpdate();
            }

            if (timerSeconds > gameTimerMax)
            {
                timerSeconds = 0;
                gameActive = false;
                TimerTextUpdate();
            }
        }



        for (int i = 0; i < 4; i++)
        {
            if (meterValues[i] > 0)
                meterValues[i] -= meterDecreaseSpeed * Time.deltaTime;
        }

        UpdateMeterValues();     
    }


    void TimerTextUpdate()
    {
        timerText.GetComponent<Text>().text = ("" + timerSeconds + " / " + gameTimerMax);

        if (!gameActive)
        {
            timerText.SetActive(false);
            endText.SetActive(true);
            endText.GetComponent<Text>().text = ("Very Cool");
        }
    }

    void LoseGame()
    {
        gameActive = false;
        timerText.SetActive(false);
        endText.SetActive(true);
        endText.GetComponent<Text>().text = ("Not very cool >:(");
    }



    public void UpdateMeterValues()
    {
        //update displayed value for each meter
        for (int i = 0; i<4; i++)
        {
            if (meterValues[i] <= 0)
            {
                foreach (GameObject furnishing in (GameObject.FindGameObjectsWithTag("Interactable")))
                {
                    if (furnishing.GetComponent<stageInteraction>().furnitureID == i)
                    {
                        furnishing.GetComponent<stageInteraction>().InteractionDeath();
                        meterDecreaseSpeed += meterDecreaseAccel;
                        deaths++;
                        if (deaths >= 4)
                        {
                            LoseGame();
                        }
                    }
                }
            }
            else
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
