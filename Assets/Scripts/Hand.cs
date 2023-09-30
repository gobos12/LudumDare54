using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform hand;

    public Camera camera;
    public Ray cameraRay;
    public Vector3 camPos;

    public Vector3 screenPoint;
    public Vector3 offset;

    public float zPos;
    // Start is called before the first frame update
    void Start()
    {
        zPos = camera.nearClipPlane;
    }

    // Update is called once per frame
    void Update()
    {
        cameraRay = camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            camera.transform.position.z));

        //hand.position = new Vector3(cameraRay.origin.x + cameraRay.direction.x, cameraRay.origin.y + cameraRay.direction.y, zPos);

        camPos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            zPos));
        hand.position = camPos;
        
        Debug.Log($"mouse={Input.mousePosition}, hand={camPos}, swp={camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.transform.position.z))}");
        
        /*screenPoint = camera.WorldToScreenPoint(hand.position);
        offset = hand.position -
                 camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        camPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Debug.Log($"screenpoint={screenPoint}, offset={offset},camPos={camPos}");*/

        if (Input.mouseScrollDelta.y < 0) //scroll up
        {
            if (zPos > -0.43f)
            {
                zPos -= 0.1f;
            }
        }
        else if (Input.mouseScrollDelta.y > 0) //scroll down
        {
            if (zPos < 3.8f)
            {
                zPos += 0.1f;
            }
        }
    }
    
}
