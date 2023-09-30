using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public static Hover singleton;
    
    public Camera camera;
    public Ray ray;
    public RaycastHit hit;

    public GameObject target;

    private void Start()
    {
        singleton = this;
    }

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            target = hit.collider.gameObject;
            
        }
        else
        {
            target = null;
        }


        Debug.DrawRay(ray.origin, ray.direction, Color.white);
    }

    public Vector3 currentMousePosition()
    {
        return ray.origin + ray.direction;
    }
}
