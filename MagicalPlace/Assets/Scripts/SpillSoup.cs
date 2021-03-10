using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillSoup : MonoBehaviour
{
    public GameObject soup;
    public float timerMax;
    public LayerMask kitchenTile;



    [SerializeField]
    private bool isRecharging = false;
    private float timer;
    private float timerSeconds;
    
    void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Jump")) == 1 && !isRecharging)
        {
            if (Physics2D.OverlapCircle(transform.position, 0.3f, kitchenTile))
            {
                RestoreSoup();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().UpdateSoup();
            }
            else
            {
                if (GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().soupInventory > 0)
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().soupInventory--;
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().UpdateSoup();
                    CreateSoup();
                }
            }
        }


        //timer until soup can be dumped or recharged again
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

    void RestoreSoup()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().soupInventory++;
        isRecharging = true;
    }
}
