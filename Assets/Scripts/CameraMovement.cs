using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float lerpDuration;
    public float elapsedTime;
    
    public bool targetHit;

    void Start()
    {
        lerpDuration = 0.5f;
        elapsedTime = 0f;
        targetHit = false;
    }
    void Update()
    {
        if (targetHit)
        {
            CameraSlerp();
        }
    }
    
    
    public void CameraSlerp()
    {
        if (elapsedTime < lerpDuration)
        {
            transform.position = Vector3.Lerp(new Vector3(0,0,2), new Vector3(0,0,0.5f), elapsedTime / lerpDuration);
            transform.rotation = Quaternion.Slerp(new Quaternion(0, 180, 0, 0), new Quaternion(0, 180, -90, 0), elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            targetHit = false;
        }
        
        //gameObject.
    }
    
    
    
    
    
}
