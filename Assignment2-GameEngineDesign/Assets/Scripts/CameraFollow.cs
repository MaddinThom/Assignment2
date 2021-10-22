using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 cameraOffset;
    public float lerpFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position; //gets the offset of the camera position
    }

    
    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset; //creates the new position
        transform.position = Vector3.Slerp(transform.position, newPosition, lerpFactor); //slerps the positions for a smooth movement
    }
}
