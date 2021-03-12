using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveToTutorialScreen : MonoBehaviour
{
    public string sceneName;
    private void FixedUpdate()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        {
            ChangeScene();
        }
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            ChangeScene();
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
