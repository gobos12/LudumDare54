using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class itemSpawn : MonoBehaviour
{
    public List<GameObject> foodList = new List<GameObject>();

    void OnMouseDown()
   {
      RaycastHit hit = RayFromCamera(Input.mousePosition);

      int index = Random.Range (0, foodList.Count); 
      var go = GameObject.Instantiate(foodList[index], hit.point, Quaternion.identity);
      go.AddComponent<ObjectSnap>();
      go.GetComponent<MeshCollider>().enabled = false;
      go.tag = "Food";
      
      DragAndDrop.singleton.holding = true; //holding food item
      DragAndDrop.singleton.justSpawnedItem = true;
      DragAndDrop.singleton.target = go;
   }

   void OnMouseUp(){
    //dd.holding = true;
   }

    public RaycastHit RayFromCamera(Vector3 mousePosition)
    {
     RaycastHit hit;
     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
     Physics.Raycast(ray.origin, ray.direction, out hit);
     return hit;
    }
}
