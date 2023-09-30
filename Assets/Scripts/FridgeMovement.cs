using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeMovement : MonoBehaviour
{
    /*public Camera camera;
    private Ray ray;
    public RaycastHit hit;*/

    public Texture2D pointer;
    public Texture2D cursor;

    public Transform ogCameraPos;

    public GameObject gameController;
    public LayerMask ignoreLayer;

    // Update is called once per frame
    void Update()
    {
        /*
        if (Hover.singleton.target != null && Hover.singleton.target.tag.Contains("Fridge"))
        {
            OpenDoor(Hover.singleton.target, Hover.singleton.camera);
        }
        */
        Ray ray = Hover.singleton.camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000f, ~ignoreLayer))
        {
            OpenDoor(hit.collider.gameObject, Hover.singleton.camera);
        }

    }

    private void OpenDoor(GameObject target, Camera camera)
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (target.name.Contains("Door"))
            {   Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
                target.transform.rotation = target.GetComponent<ObjectState>().isOpen ? new Quaternion(0, 0, 0, 0) : new Quaternion(0, 180, 0, 0);
                target.GetComponent<ObjectState>().isOpen =
                    !target.GetComponent<ObjectState>().isOpen;
            }
            else if(target.name.Contains("Drawer"))//Drawers
            {   Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
                if (target.GetComponent<ObjectState>().isOpen)
                {
                    target.transform.position -= new Vector3(0, 0, 0.8f);
                    camera.gameObject.GetComponent<CameraMovement>().startPosition = camera.transform;
                    camera.gameObject.GetComponent<CameraMovement>().endPosition = ogCameraPos.position;
                    camera.gameObject.GetComponent<CameraMovement>().rotationAngle = 0f;
                }
                else
                {   
                    target.transform.position += new Vector3(0, 0, 0.8f);
                    camera.gameObject.GetComponent<CameraMovement>().startPosition = camera.transform;
                    camera.gameObject.GetComponent<CameraMovement>().endPosition =
                        target.transform.position + new Vector3(0, 1, 0);
                    camera.gameObject.GetComponent<CameraMovement>().rotationAngle = 90f;
                }
                
                camera.gameObject.GetComponent<CameraMovement>().slerpTargetHit = true;
                
                target.GetComponent<ObjectState>().isOpen =
                    !target.GetComponent<ObjectState>().isOpen;
                
            }
            else if (target.name.Contains("Section") || target.name.Contains("Waste")) //fridge section
            {   Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
                if (target.gameObject.GetComponent<ObjectState>().isOpen)
                {
                    camera.gameObject.GetComponent<CameraMovement>().startPosition = camera.transform;
                    camera.gameObject.GetComponent<CameraMovement>().endPosition = ogCameraPos.position;
                    
                    if (target.name.Contains("Waste"))
                    {
                        gameController.GetComponent<DragAndDrop>().inTrash = false;
                    }
                }
                else
                {
                    camera.gameObject.GetComponent<CameraMovement>().startPosition = camera.transform;
                    camera.gameObject.GetComponent<CameraMovement>().endPosition =
                        target.transform.position + new Vector3(0,0,1f);
                    
                    if (target.name.Contains("Waste"))
                    {
                        gameController.GetComponent<DragAndDrop>().inTrash = true;
                    }
                }
                
                camera.gameObject.GetComponent<CameraMovement>().lerpTargetHit = true;

                target.GetComponent<ObjectState>().isOpen =
                    !target.GetComponent<ObjectState>().isOpen;
            }
        }
        
    }
    
}
