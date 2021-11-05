using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceKey : KeyInterface
{
    Vector3 position;
    Transform key;
    static List<Transform> keyT = new List<Transform>();

    public PlaceKey(Vector3 position, Transform key)
    {
        this.position = position;
        this.key = key;
    }

    public void PlacingKey()
    {
        OpenDoor.IncTotalKey();
        keyT.Add(key);
        //KeyPlacer.PlaceKey(position, key);
        if (OpenDoor.GetDoorOpen() == false) //only works for the door being closed
        {
            var keyObject = ObjectPool.Instance.GetFromPool();
            keyObject.transform.position = position;
        }
    }

    public void RemovingKey()
    {
        if (OpenDoor.GetTotalKeys() > 1) //prevents having 0 keys
        {
            OpenDoor.DecTotalKey();

            //KeyPlacer.RemoveKey(position);
            if (OpenDoor.GetDoorOpen() == false) //only works for the door being closed
            {
                Debug.Log("Yo: " + keyT.Count);
                GameObject.Destroy(keyT[keyT.Count-1].gameObject);
                keyT.RemoveAt(keyT.Count-1);
            }
        }


    }
}
