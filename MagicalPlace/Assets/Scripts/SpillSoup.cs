using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillSoup : MonoBehaviour
{
    public GameObject soup;
    public float timerMax;

    private bool isRecharging = false;
    private float timer;
    private float timerSeconds;
    
    void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Jump")) == 1 && !isRecharging)
        {
            CreateSoup();
        }

        if (isRecharging)
        {
            timer++;
            if (timer % 60 == 0)
            {
                timerSeconds++;
            }

            if (timerSeconds >= timerMax)
            {
                isRecharging = false;
                timerSeconds = 0;
            }
        }
    }

    void CreateSoup()
    {
        Instantiate(soup, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        isRecharging = true;
    }
}
