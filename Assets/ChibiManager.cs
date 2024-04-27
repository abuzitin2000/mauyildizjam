using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChibiManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI infoText;

    public List<string> day1Infos;
    public List<string> day2Infos;
    public List<string> day3Infos;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
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
            gameObject.SetActive(false);
        }
    }

    public void ShowChibi(int day, int index)
    {
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

        gameObject.SetActive(true);
    }
}
