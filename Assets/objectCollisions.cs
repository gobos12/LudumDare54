using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectCollisions : MonoBehaviour
{
    public bool colliding = false;
    

    void OnCollisionEnter (Collision col){
        colliding = true;
        Debug.Log("collision happening");
        if (col.gameObject.tag == "Food")
        {
            DragAndDrop.singleton.colliding = true;
        }
    }
    void OnCollisionStay (Collision col){
        if (col.gameObject.tag == "Food")
        {
            DragAndDrop.singleton.colliding = true;
        }
    }
     void OnCollisionExit (Collision col){
        colliding = false;
        if (col.gameObject.tag == "Food")
        {
            DragAndDrop.singleton.colliding = false;
        }
    }
}
