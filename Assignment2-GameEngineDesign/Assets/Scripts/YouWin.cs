using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{

    void OnCollisionEnter(Collision gameObjectInfo)
    {
           if (gameObjectInfo.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("WinScene");//win scene
            }
        

    }

}
