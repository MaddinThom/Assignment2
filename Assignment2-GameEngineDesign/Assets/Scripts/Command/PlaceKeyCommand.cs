using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceKeyCommand : ICommand
{
    int keycount = 1;

    Vector3 position;
    Transform Key;

    public PlaceKeyCommand(Vector3 position, Transform Key)
    {
        this.position = position;
        this.Key = Key;
    }

    public void Execute()
    {
        keycount++;
        OpenDoor.SetTotalKey(keycount);
        KeyPlacer.PlaceKey(position, Key);
    }

    public void Undo()
    {
        if (keycount > 1) //prevents having 0 keys
        {
            keycount--;
            OpenDoor.SetTotalKey(keycount);
        }

        KeyPlacer.RemoveKey(position);
    }
}

