using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void Update()
    {
        int health = PlayerHealth.Instance.GetHealth(); //get the health

        if (health <= 0) //if health is 0 or less
        {
            SceneManager.LoadScene("GameOver");//gameover scene
        }
    }
    void OnCollisionEnter(Collision gameObjectInfo)
    {
        if (gameObjectInfo.gameObject.tag == "Player") 
        {
            SceneManager.LoadScene("GameOver");//gameover scene
        }

    }

}
