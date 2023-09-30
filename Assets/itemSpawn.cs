using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawn : MonoBehaviour
{
    public List<GameObject> foodList = new List<GameObject>();

    public DragAndDrop dd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

     void OnMouseDown()
   {
     
      RaycastHit hit = RayFromCamera(Input.mousePosition, 1000.0f);

            int index = Random.Range (0, foodList.Count); 
            var go = GameObject.Instantiate(foodList[index], hit.point, Quaternion.identity);

            go.transform.position = new Vector3(1.3f, -0.1f, 1f );
            
            dd.offset = new Vector3(0f,0f,0f);
            dd.target = go;
            dd._mouseState = true;
            dd.justSpawnedItem = true; 
            Debug.Log("DD MouseState is " + dd._mouseState);
   }

   void OnMouseUp(){
    //dd._mouseState = true;
   }

    public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
{
     RaycastHit hit;
     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
     Physics.Raycast(ray, out hit, rayLength);
     return hit;
}
}
