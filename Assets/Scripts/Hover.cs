using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public static Hover singleton;
    
    public Camera camera;

    public RaycastHit hit;
    public Ray ray;

    public Transform hand;
    public GameObject target;

    private void Start()
    {
        singleton = this;
        //Cursor.visible = false;
    }

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000f))
        //if (Physics.Raycast(hand.position, camera.transform.forward, out hit, 1000f))
        {
            target = hit.collider.gameObject;
        }
        else
        {
            target = null;
        }
    }

    public void turnOffCursor()
    {
        Cursor.visible = false;
    }

    /*public Vector3 currentMousePosition()
    {
        return cameraRay.origin + cameraRay.direction;
    }*/
}
