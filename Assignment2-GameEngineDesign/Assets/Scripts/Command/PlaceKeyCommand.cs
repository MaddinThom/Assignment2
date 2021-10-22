using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceKeyCommand : ICommand
{
    
    Vector3 position;
    Transform Key;

    public PlaceKeyCommand(Vector3 position, Transform Key)
    {
        this.position = position;
        this.Key = Key;
    }

    public void Execute()
    {
        OpenDoor.IncTotalKey();
        KeyPlacer.PlaceKey(position, Key);
    }

    public void Undo()
    {
        if (OpenDoor.GetTotalKeys() > 1) //prevents having 0 keys
        {
            OpenDoor.DecTotalKey();
            KeyPlacer.RemoveKey(position);
        }

        
    }
}

