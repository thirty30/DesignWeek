using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillSoup : MonoBehaviour
{
    public GameObject soup;
    public float timerMax;
    public LayerMask kitchenLayer;



    [SerializeField]
    private bool isRecharging = false;
    private float timer;
    private float timerStep;
    
    void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Jump")) == 1 && !isRecharging)
        {
            
            
            if (Physics2D.OverlapCircle(transform.position, 0.3f, kitchenLayer))
            {
                RestoreSoup();
                GetComponent<GridMovement>().isRecharging = true;
                this.GetComponent<Animator>().SetBool("fillSoup", true);
                GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().UpdateSoup();
            }
            else
            {
                if (GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().soupInventory > 0)
                {
                    UIHelper.ShowTips("Presto !!");
                    AudioManager.GetSingleton().PlaySound("Soup_Pour");
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().soupInventory--;
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<meterManager>().UpdateSoup();
                    this.GetComponent<Animator>().SetBool("pourSoup", true);
                    GetComponent<GridMovement>().isRecharging = true;
                    CreateSoup();
                }
            }
        }
    }

    void FixedUpdate()
    {
        //timer until soup can be dumped or recharged again
        if (isRecharging)
        {
            timer+= Time.deltaTime;
            if (timer >= timerMax)
            {
                this.GetComponent<Animator>().SetBool("fillSoup", false);
                this.GetComponent<Animator>().SetBool("pourSoup", false);
                GetComponent<GridMovement>().isRecharging = false;
                isRecharging = false;
                timer = 0;
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
