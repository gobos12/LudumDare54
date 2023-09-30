using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeMovement : MonoBehaviour
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    public Camera camera;
    private Ray ray;
    private RaycastHit hit;

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
                hit.collider.gameObject.transform.position = hit.collider.gameObject.GetComponent<ObjectState>().isOpen ? new Vector3(0, 0, 0) : new Vector3(0, 0, 0.5f);
                camera.gameObject.GetComponent<CameraMovement>().targetHit = true;
                hit.collider.gameObject.GetComponent<ObjectState>().isOpen =
                    !hit.collider.gameObject.GetComponent<ObjectState>().isOpen;
                
            }
        }
        
    }
    
}
