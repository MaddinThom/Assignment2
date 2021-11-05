using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceKey : KeyInterface
{
    Vector3 position;
    Transform key;

    public PlaceKey(Vector3 position, Transform key)
    {
        this.position = position;
        this.key = key;
    }

    public void PlacingKey()
    {
        OpenDoor.IncTotalKey();

        // Place key from object pool
        if (OpenDoor.GetDoorOpen() == false) //only works for the door being closed
        {
            var keyObject = ObjectPool.Instance.GetFromPool();
            keyObject.transform.position = position;
        }
    }
}
