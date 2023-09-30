using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableMesh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Hover.singleton.fridgeTarget != null && Hover.singleton.fridgeTarget.name.Equals(gameObject.name))
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
