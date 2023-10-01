using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class DragAndDrop : MonoBehaviour
{
    public static DragAndDrop singleton;
    public bool holding = false;
    public GameObject hand;
     
    public GameObject target;
    public Vector3 screenSpace;
    public Vector3 offset;
    public bool justSpawnedItem = false;

    public Texture2D cursor;
    public Texture2D cursor2;

    public bool inTrash = false;
    public LayerMask ignoreLayer;

    public bool colliding = false;

    private void Start()
    {
        singleton = this;
    }

    void Update ()
    {
        if (target != null)
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
        

    }

    void NormalItemUpdate()
    {
        if (Input.GetMouseButtonDown (0)) {
            if (holding)
            {
                //target.GetComponent<MeshCollider>().enabled = true;
                if(inTrash){
                    if(target!=null){
                        Destroy(target);
                        Points.singleton.pointCount -= 5;
                        gameObject.GetComponent<AudioSource>().Play();
                        Points.singleton.trashCount ++;
                        if( Points.singleton.trashCount >= 3){
                            Points.singleton.gameOver();
                        }
                        holding = false;
                    }
                }
                else{
                    if(!colliding){
                    
                    if (target != null && target.GetComponent<ObjectSnap>())
                    {
                            if(target.GetComponent<ObjectSnap>().SnapSuccess()){
                                Points.singleton.pointCount += 5;
                                target.transform.parent = (target.GetComponent<ObjectSnap>().hit.collider.gameObject.transform);
                                holding = false;
                              //  Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
                                
                                target.GetComponent<ObjectSnap>().isBeingSnapped = false;
                            }
                        }
                    }
                }
            }
            else if(holding == false)
            {
                //target.GetComponent<MeshCollider>().enabled = false;
                RaycastHit hitInfo;
                //Hover.singleton.ignoreLayer = ignoreLayer;
                //target = Hover.singleton.target;
                GameObject localTarget = GetClickedObject(out hitInfo);
                if (localTarget != null && localTarget.tag != "Crate" && localTarget.tag != "Fridge") {
                    
                  //  Cursor.SetCursor(cursor2, Vector2.zero, CursorMode.Auto);
                    holding = true;
                    //screenSpace = Camera.main.WorldToScreenPoint (target.transform.position);
                    //offset = target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                }
            }
        }
        
        if (holding) {
            //var curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            //var curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;

            target.transform.position = hand.transform.position;
        }
    }

    void SpawnedItemUpdate()
    {
        //Cursor.SetCursor(cursor2, Vector2.zero, CursorMode.Auto);
        screenSpace = Camera.main.WorldToScreenPoint (target.transform.position);
        var curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

        offset = target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));

        var curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;

        target.transform.position = hand.transform.position;

        justSpawnedItem = false;
    }

     void OnMouseDown()
   {

   }

    GameObject GetClickedObject (out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray.origin, ray.direction * 10, out hit, 1000f, ~ignoreLayer)) {
            if (hit.collider.gameObject.tag != "Fridge")
            {
                target = hit.collider.gameObject;
            }
        }

        return target;
    }
    
}
