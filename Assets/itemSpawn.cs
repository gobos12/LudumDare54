using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawn : MonoBehaviour
{
    public List<GameObject> foodList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("up")){

            RaycastHit hit = RayFromCamera(Input.mousePosition, 1000.0f);

            int index = Random.Range (0, foodList.Count-1); 
            var go = GameObject.Instantiate(foodList[index], hit.point, Quaternion.identity);
            go.transform.position = Input.mousePosition;

        }
    }

    public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
{
     RaycastHit hit;
     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
     Physics.Raycast(ray, out hit, rayLength);
     return hit;
}
}
