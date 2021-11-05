using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    Camera cam; // camera
    RaycastHit hitInfo; // detecting where the player clicks

    public Transform key; // key
    private List<KeyInterface> k = new List<KeyInterface>(); // keys in game

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // click detection to add a key
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                KeyInterface keyIn = new PlaceKey(hitInfo.point, key); // create a new key
                keyIn.PlacingKey(); // place key
                k.Add(keyIn); // add to key list
            }
        }
    }
}
