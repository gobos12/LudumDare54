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

    public GameObject fridgeTarget;
    public RaycastHit fridgeHit;
    public int fridgeLayer;

    public Transform hand;
    public GameObject target;

    private void Start()
    {
        singleton = this;
        fridgeLayer = 3;
    }

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out fridgeHit, 1000f, fridgeLayer))
        {
            fridgeTarget = fridgeHit.collider.gameObject;
        }
        else if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000f, ~fridgeLayer))
        {
            target = hit.collider.gameObject;
        }
        else
        {
            fridgeTarget = null;
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
