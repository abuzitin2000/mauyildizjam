using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Image timerBar;
    public ChibiManager chibi;

    public SpriteRenderer girl;
    public List<Sprite> girlSprites;

    public GameObject chair;

    public int day;
    public int progress;
    public float timerInitial;
    
    public float timer;
    private float timerBarInitialWidth;

    private float resetTimer;
    private bool dead;

    public bool daydone;

    private float donetimer;

    public GameObject END;

    // Start is called before the first frame update
    void Start()
    {
        timerBarInitialWidth = timerBar.rectTransform.sizeDelta.x;
        timer = timerInitial;

        chibi.ShowChibi(day, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (END.activeSelf && Input.anyKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (daydone)
        {
            donetimer += Time.deltaTime;

            if (donetimer > 4f)
            {
                if (day == 0)
                    SceneManager.LoadScene("day2");
                else
                    SceneManager.LoadScene("bitis");
            }

            return;
        }

        if (timer > 0f)
        {
            timer -= Time.deltaTime;

            if (day == 0)
            {
                if (0.2f > timer / timerInitial)
                {
                    girl.sprite = girlSprites[3];
                    chibi.ShowChibi(day, 2);
                    chair.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                }
                else if (0.4f > timer / timerInitial)
                {
                    girl.sprite = girlSprites[2];
                }
                else if (0.8f > timer / timerInitial)
                {
                    girl.sprite = girlSprites[1];
                    chibi.ShowChibi(day, 1);
                }
                else
                {
                    girl.sprite = girlSprites[0];
                }
            }
            else if (day == 1)
            {
                if (0.2f > timer / timerInitial)
                {
                    chibi.ShowChibi(day, 1);
                }
                else if (0.4f > timer / timerInitial)
                {
                    girl.sprite = girlSprites[6];
                }
                else
                {
                    girl.sprite = girlSprites[5];
                    girl.transform.position = new Vector3(girl.transform.position.x, -0.55f, 0f);
                }
            }
        }
        else
        {
            LoseLevel();
            chibi.ShowChibi(day, 3);
        }

        timerBar.rectTransform.sizeDelta = new Vector2(timerBarInitialWidth * (timer / timerInitial), timerBar.rectTransform.sizeDelta.y);
    }

    public void LoseLevel()
    {
        if (day == 0)
        {
            girl.sprite = girlSprites[4];
        }
        else if (day == 1)
        {

        }
        
        Debug.Log("End");

        if (dead)
        {
            if (resetTimer < 0f)
            {
                END.SetActive(true);
            }
            else
            {
                resetTimer -= Time.deltaTime;
            }
        }
        else
        {
            dead = true;
            resetTimer = 3f;
        }
    }

    public void OpenFirstLock()
    {
        if(GameObject.FindGameObjectWithTag("Anahtar1"))
        {
            GameObject.FindGameObjectWithTag("Gilit1").SetActive(false);
        }
    }

    public void OpenSecondLock()
    {
        if(GameObject.FindGameObjectWithTag("Anahtar2"))
        {
            GameObject.FindGameObjectWithTag("Gilit2").SetActive(false);
        }
    }

    public void Kes()
    {
        if (GameObject.FindGameObjectWithTag("Knife"))
        {
            if (progress > 0)
            {
                girl.sprite = girlSprites[7];
                chibi.ShowChibi(day, 7);

                daydone = true;
            }
            else
            {
                chibi.ShowChibi(0, 6);
            }
        }
        else
        {
            chibi.ShowChibi(0, 5);
        }
    }

    public void Al()
    {
        Debug.Log("aaaaa");
        if (GameObject.FindGameObjectWithTag("Gun"))
        {
            girl.sprite = girlSprites[7];
            chibi.ShowChibi(1, 5);

            daydone = true;
        }
        else
        {
            chibi.ShowChibi(1, 4);
        }
    }
}
