using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points singleton;
    public int pointCount = 0;

    public int trashCount = 0;

    public TMP_Text pointText; 
    public TMP_Text finalpointText; 

    public GameObject gameOverScreen;
    void Start()
    {
        trashCount = 0;
        singleton = this;
        pointText.text = $"Score: {pointCount}";
    }

    void Update()
    {
        pointText.text = $"Score: {pointCount}";
        finalpointText.text = $"Final Score: {pointCount}";

    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
        Hover.singleton.turnOnCursor();
    }
}
