using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Image timerBar;
    public ChibiManager chibi;
    public Animator girl;

    public int day;
    public int progress;
    public float timerInitial;
    
    public float timer;
    private float timerBarInitialWidth;

    // Start is called before the first frame update
    void Start()
    {
        timerBarInitialWidth = timerBar.rectTransform.sizeDelta.x;
        timer = timerInitial;

        chibi.ShowChibi(day, progress);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Debug.Log("End");
        }

        timerBar.rectTransform.sizeDelta = new Vector2(timerBarInitialWidth * (timer / timerInitial), timerBar.rectTransform.sizeDelta.y);
    }
}
