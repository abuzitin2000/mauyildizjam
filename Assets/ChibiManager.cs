using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChibiManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI infoText;
    public Image infoShadow;

    public List<string> day1Infos;
    public List<string> day2Infos;
    public List<string> day3Infos;

    private float timer;
    private int lastindex = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > -1f)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0f)
        {
            gameObject.GetComponent<CanvasRenderer>().SetColor(new Color(1f, 1f, 1f, 1f + timer));
            infoShadow.GetComponent<CanvasRenderer>().SetColor(new Color(1f, 1f, 1f, 1f + timer));
            infoText.GetComponent<CanvasRenderer>().SetColor(new Color(1f, 1f, 1f, 1f + timer));
        }
    }

    public void ShowChibi(int day, int index)
    {
        if (index == lastindex)
            return;

        lastindex = index;
        timer = 5f;

        switch (day)
        {
            case 0:
                infoText.text = day1Infos[index];
                break;
            case 1:
                infoText.text = day2Infos[index];
                break;
            case 2:
                infoText.text = day3Infos[index];
                break;
        }

        gameObject.GetComponent<CanvasRenderer>().SetColor(new Color(1f, 1f, 1f, 1f));
        infoShadow.GetComponent<CanvasRenderer>().SetColor(new Color(1f, 1f, 1f, 1f));
        infoText.GetComponent<CanvasRenderer>().SetColor(new Color(1f, 1f, 1f, 1f));
    }
}
