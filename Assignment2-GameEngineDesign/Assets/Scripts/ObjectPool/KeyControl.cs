using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    Camera cam;
    RaycastHit hitInfo;
    public Transform key;
    private List<PlaceKey> keys = new List<PlaceKey>();
    private List<KeyInterface> k = new List<KeyInterface>();
    private List<KeyInterface> discardedKeys = new List<KeyInterface>();

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                //keys.Add(new PlaceKey(hitInfo.point, key));
                KeyInterface keyIn = new PlaceKey(hitInfo.point, key);
                keyIn.PlacingKey();
                k.Add(keyIn);
                Debug.Log("Place Key");
            }
            discardedKeys.Clear();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (OpenDoor.GetTotalKeys() > 0)
            {
                Debug.Log(k.Count);
                k[k.Count - 1].RemovingKey();
                discardedKeys.Add(k[k.Count - 1]);
                k.RemoveAt(k.Count - 1);

                //keys[OpenDoor.GetTotalKeys() - 1].RemovingKey();
                //discardedKeys.Add(keys[OpenDoor.GetTotalKeys()-1]);
                //keys.RemoveAt(OpenDoor.GetTotalKeys()-1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (discardedKeys.Count != 0)
            {
                discardedKeys[discardedKeys.Count - 1].PlacingKey();
                k.Add(discardedKeys[discardedKeys.Count - 1]);
                discardedKeys.RemoveAt(discardedKeys.Count - 1);

                //Debug.Log(OpenDoor.GetTotalKeys());
                //discardedKeys[OpenDoor.GetTotalKeys() - 1].PlacingKey();
                //keys.Add(discardedKeys[OpenDoor.GetTotalKeys() - 1]);
                //discardedKeys.RemoveAt(OpenDoor.GetTotalKeys() - 1);
            }
        }
    }
}
