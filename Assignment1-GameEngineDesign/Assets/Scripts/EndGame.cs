using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    void OnCollisionEnter(Collision gameObjectInfo)
    {
        if (gameObjectInfo.gameObject.tag == "Player") 
        {
            SceneManager.LoadScene("GameOver");//gameover scene
        }

    }

}
