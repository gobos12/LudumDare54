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
    public TMP_Text timeText;
    public TMP_Text finalpointText;
    public TMP_Text sarcasticText;

    public List<AudioClip> sounds = new List<AudioClip>();
    public float Timer;

    public AudioSource music;

    public GameObject gameOverScreen;
    public GameObject uiScreen;
    void Start()
    {
        trashCount = 0;
        singleton = this;
        pointText.text = $"Score: {pointCount}";
        Timer = 100.0f;
    }

    void Update()
    {
        pointText.text = $"Score:{pointCount}";
        timeText.text = $"Time:{(int)Timer}";

        Timer -= Time.deltaTime;

        if (Timer <= 0.0f)
        {
            gameOver();
        }
    }

    public void gameOver(){
        finalpointText.text = $"Final Score: {pointCount}";
        if (pointCount > 0)
        {
            sarcasticText.text = $"good job ... i guess";
        }
        else
        {
            sarcasticText.text = $"wow ... even my parents are disappointed";
        }
        gameOverScreen.SetActive(true);
        Hover.singleton.turnOnCursor();
        uiScreen.SetActive(false);

    }
}
