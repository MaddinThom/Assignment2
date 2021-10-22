using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DestroyAll("Lock"); //called my function bellow
        }
    }

    void DestroyAll(string tag) //function made to take a take and destroy all with that tag
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag(tag);

        for (int i = 0; i < obj.Length; i++)
        {
            GameObject.Destroy(obj[i]);
        }
    }

}
