using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soupActivation : MonoBehaviour
{
    public float soupRadius;
    private void Awake()
    {
        foreach (GameObject furnishing in (GameObject.FindGameObjectsWithTag("Interactable")))
        {
            if (Vector2.Distance(transform.position, furnishing.transform.position) <= soupRadius)
            {
                furnishing.GetComponent<stageInteraction>().RechargeMeter();
            }
        }
    }
}
