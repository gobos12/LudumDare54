using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSnap : MonoBehaviour
{
    //Maybe raycast from object down, check where the nearest fridge bottom is, get half of object's height and snap

    private float objectHeight;

    public bool isBeingSnapped = false;
    // Start is called before the first frame update
    void Start()
    {
        objectHeight = GetComponent<Collider>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBeingSnapped)
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10))
            {
                if (hit.collider.gameObject.tag == "Fridge")
                {
                    Debug.Log("snapped");
                    transform.position = hit.point;
                    isBeingSnapped = true;
                }
            }
        }
        Debug.DrawRay(transform.position, Vector3.down * 100, Color.red);
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.gameObject);
    }
}
