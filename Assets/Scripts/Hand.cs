using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform hand;

    public Camera camera;

    public float zPos;
    // Start is called before the first frame update
    void Start()
    {
        zPos = hand.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        hand.position = new Vector3(Hover.singleton.ray.origin.x + Hover.singleton.ray.direction.x, Hover.singleton.ray.origin.y + Hover.singleton.ray.direction.y, zPos);

        if (Input.mouseScrollDelta.y > 0) //scroll up
        {
            if (zPos > -0.43f)
            {
                zPos -= 0.1f;
            }
        }
        else if (Input.mouseScrollDelta.y < 0) //scroll down
        {
            if (zPos < 3.8f)
            {
                zPos += 0.1f;
            }
        }
    }
}
