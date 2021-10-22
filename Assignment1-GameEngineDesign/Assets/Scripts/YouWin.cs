using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{

    public bool Win = true;

    void OnCollisionEnter(Collision gameObjectInfo)
    {
        if(Win == true)
        {
            if (gameObjectInfo.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("WinScene");//win scene
            }
        }

    }

}
