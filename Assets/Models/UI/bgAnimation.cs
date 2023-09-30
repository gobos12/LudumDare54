using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class bgAnimation : MonoBehaviour
{
    public List<Sprite> frames = new List<Sprite>();
    public List<Color> colors = new List<Color>();

    public Image image;
    public TMP_Text name;

    public float index;
    // Start is called before the first frame update
    void Start()
    {
        colors.Add(Color.green);   
        colors.Add(Color.red);   
        colors.Add(Color.blue);   
        colors.Add(Color.yellow);   
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = frames[(int)(Math.Floor(index))];
        name.color = colors[(int)(Math.Floor(index))];

        if (index >= frames.Count-1)
        {
            index = 0;
        }
        else
        {
            index += 0.045f;
        }
    }
}
