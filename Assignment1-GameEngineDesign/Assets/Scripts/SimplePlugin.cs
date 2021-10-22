using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class SimplePlugin : MonoBehaviour
{
    
    [DllImport("WinChange")]
    private static extern bool ChangeWin(bool b1); //loads in my dll function

    // Start is called before the first frame update
    void Start()
    {
        GameObject Exit = GameObject.Find("Exit"); //finds the object named exit
        YouWin YouWin = Exit.GetComponent<YouWin>(); //gets the script component of exit
        YouWin.Win = ChangeWin(YouWin.Win); //uses my function to change win condition
        Debug.Log(YouWin.Win); //displays the bool in the console

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
