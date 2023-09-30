using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float lerpDuration;
    public float elapsedTime;
    
    public bool targetHit;
    public bool target2Hit;
    public Transform startPosition;
    public Vector3 endPosition;
    public float rotationAngle;

    void Start()
    {
        startPosition = null;
        lerpDuration = 0.5f;
        elapsedTime = 0f;
        targetHit = false;
    }
    void Update()
    {
        if (targetHit)
        {
            CameraSlerp(startPosition, endPosition);
        }

        if (target2Hit)
        {
            CameraLerp(startPosition, endPosition);
        }
    }
    
    
    public void CameraSlerp(Transform start, Vector3 end)
    {
        if (elapsedTime < lerpDuration)
        {
            transform.position = Vector3.Lerp(start.position, end, elapsedTime / lerpDuration);
            transform.rotation = Quaternion.Slerp(start.rotation, Quaternion.Euler(rotationAngle,180,0), elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            targetHit = false;
            elapsedTime = 0;
        }
        
    }

    public void CameraLerp(Transform start, Vector3 end)
    {
        if (elapsedTime < lerpDuration)
        {
            transform.position = Vector3.Lerp(start.position, end, elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            target2Hit = false;
            elapsedTime = 0;
        }
    }
    
    
    
    
    
}
