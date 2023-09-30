using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour
{  
   
    public bool _mouseState;
     
    public GameObject target;
    public Vector3 screenSpace;
    public Vector3 offset;
    public bool justSpawnedItem = false;

    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        if (justSpawnedItem)
        {
            SpawnedItemUpdate();
            //justSpawnedItem = false;
        }
        else
        {
            NormalItemUpdate();
        }
    }

    void NormalItemUpdate()
    {
        if (Input.GetMouseButtonDown (0)) {
            if (_mouseState) {
                _mouseState = false;
                Debug.Log("Setting false");
            }
            else if(_mouseState == false){
                RaycastHit hitInfo;
                target = GetClickedObject (out hitInfo);
                if (target != null && target.tag != "Crate") {
                    _mouseState = true;
                    screenSpace = Camera.main.WorldToScreenPoint (target.transform.position);
                    offset = target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                }
            }
        }
        
        if (_mouseState) {
            var curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            
            var curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;

            target.transform.position = curPosition;
            Debug.Log(curPosition);
        }
    }

    void SpawnedItemUpdate()
    {
        screenSpace = Camera.main.WorldToScreenPoint (target.transform.position);
        var curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

        offset = target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));

        var curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;

        target.transform.position = curPosition;

        justSpawnedItem = false;
    }

     void OnMouseDown()
   {

   }

    GameObject GetClickedObject (out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray.origin, ray.direction * 10, out hit)) {
            if (hit.collider.gameObject.tag != "Fridge")
            {
                target = hit.collider.gameObject;
            }
        }

        return target;
    }
}
