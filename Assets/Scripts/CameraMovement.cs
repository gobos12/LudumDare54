using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraMovement : MonoBehaviour
{
    public float lerpDuration;
    public float elapsedTime;
    
    [FormerlySerializedAs("targetHit")] public bool slerpTargetHit;
    [FormerlySerializedAs("target2Hit")] public bool lerpTargetHit;
    public Transform startPosition;
    public Vector3 endPosition;
    public float rotationAngle;

    public Hand hand;

    void Start()
    {
        startPosition = null;
        lerpDuration = 0.5f;
        elapsedTime = 0f;
        slerpTargetHit = false;

        hand = gameObject.GetComponent<Hand>();
    }
    void Update()
    {
        if (slerpTargetHit)
        {
            CameraSlerp(startPosition, endPosition);
        }

        if (lerpTargetHit)
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
            hand.zPos = Lerp(start.position.z, end.z, elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            slerpTargetHit = false;
            elapsedTime = 0;
        }
        
    }

    public void CameraLerp(Transform start, Vector3 end)
    {
        if (elapsedTime < lerpDuration)
        {
            transform.position = Vector3.Lerp(start.position, end, elapsedTime / lerpDuration);
            hand.zPos = Lerp(start.position.z, end.z, elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            lerpTargetHit = false;
            elapsedTime = 0;
        }
    }
    
    
    float Lerp(float firstFloat, float secondFloat, float t)
    {
        return firstFloat * (1 - t) + secondFloat * t;
    }
    
    
}
