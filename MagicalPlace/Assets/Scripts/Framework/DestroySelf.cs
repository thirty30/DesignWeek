using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float DestroyDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(this.gameObject, this.DestroyDelay);
    }
}
