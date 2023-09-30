using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour
{  
   
    public bool _mouseState;
     
    public GameObject target;
    public Vector3 screenSpace;
    public Vector3 offset;
    public bool justSpawnedItem = false;

    public Texture2D cursor;
    public Texture2D cursor2;

    public bool inTrash = false;

    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        if (justSpawnedItem)
        {
            SpawnedItemUpdate();
        }
        else
        {
            NormalItemUpdate();
        }
    }

    void NormalItemUpdate()
    {
        if (Input.GetMouseButtonDown (0)) {
            if (_mouseState)
            {
                if(inTrash){
                    if(target!=null){
                        Destroy(target);
                        _mouseState = false;
                    }
                }
                else{
                _mouseState = false;
                Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
                if (target != null && target.GetComponent<ObjectSnap>())
                {
                    target.GetComponent<ObjectSnap>().isBeingSnapped = false;
                }
                }
            }
            else if(_mouseState == false){
                
                RaycastHit hitInfo;
                target = GetClickedObject (out hitInfo);
                if (target != null && target.tag != "Crate") {
                    
                Cursor.SetCursor(cursor2, Vector2.zero, CursorMode.Auto);
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
        }
    }

    void SpawnedItemUpdate()
    {
        Cursor.SetCursor(cursor2, Vector2.zero, CursorMode.Auto);
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
