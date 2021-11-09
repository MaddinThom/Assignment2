using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private int keys = 0;
    public static int TotalKeys = 1;
    public static bool DoorOpen = false; 
    private GameObject Door;

    public static event System.Action<string> keyCollected;

    public static int GetTotalKeys()
    {
        return TotalKeys;
    }
    public static void IncTotalKey()
    {
        TotalKeys++;
    }

    public static void DecTotalKey()
    {
        TotalKeys--;
    }

    public static bool GetDoorOpen()
    {
        return DoorOpen;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key") //check for key tag
        {
            Destroy(other.gameObject); //destroys that key
            keys++; //adds one to keys
            keyCollected?.Invoke("Key Collected!"); // key is collected text
        }

        if (keys == TotalKeys) //if you collect the total keys
        {
            Door = GameObject.FindGameObjectWithTag("Lock"); //finds the door
            Destroy(Door); //destroys it
            DoorOpen = true;//sets door open to true so no more keys can be placed
            keyCollected?.Invoke("Door Open!"); // door is open text
        }
    }
    
}
