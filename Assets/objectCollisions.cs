using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectCollisions : MonoBehaviour
{
    public bool colliding = false;
    

    void OnCollisionEnter (Collision col){
        
     
        if (col.gameObject.tag == "Food")
        { colliding = true;
            DragAndDrop.singleton.colliding = true;
        }
    }
    void OnCollisionStay (Collision col){
        
        if (col.gameObject.tag == "Food")
        {
              colliding = true;
         //   DragAndDrop.singleton.colliding = true;
        }
    }
     void OnCollisionExit (Collision col){
       
        if (col.gameObject.tag == "Food")
        { colliding = false;
            DragAndDrop.singleton.colliding = false;
        }
    }
}
