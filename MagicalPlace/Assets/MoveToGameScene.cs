using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToGameScene : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Jump")) == 1)
        {
            ChangeScene();
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("InteractablesTest");
    }
}
