using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSnap : MonoBehaviour
{
    //Maybe raycast from object down, check where the nearest fridge bottom is, get half of object's height and snap

    private float objectHeight;
    private float objectWidth;

    public RaycastHit hit;

    public bool isBeingSnapped = false;
    // Start is called before the first frame update
    void Start()
    {
        objectHeight = GetComponent<Collider>().bounds.size.y;
        objectWidth = GetComponent<Renderer>().bounds.size.x;
    }

    public bool SnapSuccess()
    {
        bool res = false;
        Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, out hit, 10))
            {
                if (hit.collider.gameObject != null && hit.collider.gameObject.tag == "Fridge")
                {
                    transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
                    if (Hover.singleton.camera.gameObject.GetComponent<CameraMovement>().rotationAngle == 90f)
                    {
                        transform.parent = hit.collider.transform;
                    }

                    res = true;
                }
            }


            Ray rightRay = new Ray(transform.position, Vector3.left);
            RaycastHit rightHit;
            if (Physics.Raycast(rightRay, out rightHit, objectWidth / 2))
            {
                if (hit.collider.gameObject != null && hit.collider.gameObject.tag == "Fridge" || rightHit.collider.gameObject.layer == 6)
                {
                    transform.position = new Vector3(rightHit.point.x + objectWidth / 2, transform.position.y, transform.position.z);
                    res = true;
                    
                    
                }
            }
            
            Ray leftRay = new Ray(transform.position, Vector3.right);
            RaycastHit leftHit;
            if (Physics.Raycast(leftRay, out leftHit, objectWidth / 2))
            {
                if (hit.collider.gameObject != null && hit.collider.gameObject.tag == "Fridge" || leftHit.collider.gameObject.layer == 6)
                {
                    transform.position = new Vector3(leftHit.point.x - objectWidth / 2, transform.position.y, transform.position.z);
                    res = true;
                    
                }
            }

            return res;
    }
}
