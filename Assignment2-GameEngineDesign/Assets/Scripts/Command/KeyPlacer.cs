using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlacer : MonoBehaviour
{
    static List<Transform> keyList;

    public static void PlaceKey(Vector3 position, Transform capsule)
    {
        Transform newKey = Instantiate(capsule, position, Quaternion.identity);
       
        if (keyList == null)
        {
            keyList = new List<Transform>();
        }
        keyList.Add(newKey);
    }

    public static void RemoveKey(Vector3 position)
    {
        for (int i = 0; i < keyList.Count; i++)
        {
            if (keyList[i].position == position)
            {
                GameObject.Destroy(keyList[i].gameObject);
                keyList.RemoveAt(i);
                break;
            }
        }
    }
}

