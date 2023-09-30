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
    void Start()
    {
        
    }

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
                hit.collider.gameObject.transform.rotation = hit.collider.gameObject.GetComponent<ObjectState>().isOpen ? new Quaternion(0, 0, 0, 0) : new Quaternion(0, 90, 0, 0);
                hit.collider.gameObject.GetComponent<ObjectState>().isOpen =
                    !hit.collider.gameObject.GetComponent<ObjectState>().isOpen;
            }
            else //Drawers
            {
                
            }
        }
        
    }
    
}
