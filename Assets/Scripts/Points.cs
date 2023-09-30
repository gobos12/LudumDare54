using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points singleton;
    public int pointCount = 0;

    public TMP_Text pointText; 
    void Start()
    {
        singleton = this;
        pointText.text = $"Score: {pointCount}";
    }

    void Update()
    {
        pointText.text = $"Score: {pointCount}";
    }
}
