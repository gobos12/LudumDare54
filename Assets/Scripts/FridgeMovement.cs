using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeMovement : MonoBehaviour
{
    public Camera camera;
    private Ray ray;
    public RaycastHit hit;

    public Transform ogCameraPos;

    // Update is called once per frame
    void Update()
    {
        Hover();
    }

    private void Hover()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            Debug.Log(hit.collider.name);
            OpenDoor();
        }


    }
    

    private void OpenDoor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider.name.Contains("Door"))
            {
                hit.collider.gameObject.transform.rotation = hit.collider.gameObject.GetComponent<ObjectState>().isOpen ? new Quaternion(0, 0, 0, 0) : new Quaternion(0, 180, 0, 0);
                hit.collider.gameObject.GetComponent<ObjectState>().isOpen =
                    !hit.collider.gameObject.GetComponent<ObjectState>().isOpen;
            }
            else if(hit.collider.name.Contains("Drawer"))//Drawers
            {
                if (hit.collider.gameObject.GetComponent<ObjectState>().isOpen)
                {
                    hit.collider.gameObject.transform.position -= new Vector3(0, 0, 0.8f);
                    camera.gameObject.GetComponent<CameraMovement>().startPosition = camera.transform;
                    camera.gameObject.GetComponent<CameraMovement>().endPosition = ogCameraPos.position;
                    camera.gameObject.GetComponent<CameraMovement>().rotationAngle = 0f;
                }
                else
                {
                    hit.collider.gameObject.transform.position += new Vector3(0, 0, 0.8f);
                    camera.gameObject.GetComponent<CameraMovement>().startPosition = camera.transform;
                    camera.gameObject.GetComponent<CameraMovement>().endPosition =
                        hit.collider.gameObject.transform.position + new Vector3(0, 1, 0);
                    camera.gameObject.GetComponent<CameraMovement>().rotationAngle = 90f;
                }
                
                camera.gameObject.GetComponent<CameraMovement>().targetHit = true;
                
                hit.collider.gameObject.GetComponent<ObjectState>().isOpen =
                    !hit.collider.gameObject.GetComponent<ObjectState>().isOpen;
                
            }
        }
        
    }
    
}
