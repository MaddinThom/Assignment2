using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class SimplePlugin : MonoBehaviour
{
    public int maximum = 7; //max range
    public int minimum = 3; // min range
    int number = 0; //holds new speed

    [DllImport("RandomSpeed")]
    private static extern int RandomSpeed(int min, int max); //loads in my dll function

    // Start is called before the first frame update
    void Start()
    {
        number = RandomSpeed(minimum, maximum); 
        Debug.Log(number); //displays the speed value in console
        PlayerMovement.SetSpeed(number); //sets the speed in player movement

    }

}
