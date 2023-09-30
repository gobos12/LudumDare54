using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSnap : MonoBehaviour
{
    //Maybe raycast from object down, check where the nearest fridge bottom is, get half of object's height and snap

    private float objectHeight;
    private float objectWidth;

    public bool isBeingSnapped = false;
    // Start is called before the first frame update
    void Start()
    {
        objectHeight = GetComponent<Collider>().bounds.size.y;
        objectWidth = GetComponent<Renderer>().bounds.size.x;
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
                    transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
                    isBeingSnapped = true;
                    
                   
                }
            

            Ray rightRay = new Ray(transform.position, Vector3.left);
            RaycastHit rightHit;
            if (Physics.Raycast(rightRay, out rightHit, objectWidth / 2))
            {
                if (hit.collider.gameObject.tag == "Fridge" || rightHit.collider.gameObject.layer == 6)
                {
                    transform.position = new Vector3(rightHit.point.x + objectWidth / 2, transform.position.y, transform.position.z);
                    isBeingSnapped = true;
                    
                    
                }
            }
            
            Ray leftRay = new Ray(transform.position, Vector3.right);
            RaycastHit leftHit;
            if (Physics.Raycast(leftRay, out leftHit, objectWidth / 2))
            {
                if (hit.collider.gameObject.tag == "Fridge" || leftHit.collider.gameObject.layer == 6)
                {
                    transform.position = new Vector3(leftHit.point.x - objectWidth / 2, transform.position.y, transform.position.z);
                    isBeingSnapped = true;
                    
                }
            }
            }

        }
        
        Debug.DrawRay(transform.position, Vector3.down * 10, Color.red);
        Debug.DrawRay(transform.position, Vector3.left * objectWidth / 2, Color.green);
        Debug.DrawRay(transform.position, Vector3.right * objectWidth / 2, Color.green);
    }
}
