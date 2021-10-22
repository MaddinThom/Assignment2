using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private int keys = 0;
    private int TotalKeys = 1;
    private GameObject Door;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key") //check for key tag
        {
            Destroy(other.gameObject); //destroys that key
            keys++; //adds one to keys
        }

        if (keys >= TotalKeys) //if you collect the total keys
        {
            Door = GameObject.FindGameObjectWithTag("Lock"); //finds the door
            Destroy(Door); //destroys it
        }
    }
    
}
