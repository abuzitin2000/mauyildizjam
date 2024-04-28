using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    private Camera maincamera;
    private Vector2 startPos;

    public GameObject bileshadow;

    public bool knife;

    public bool flipflop;
    public int stage;

    private void OnMouseDrag()
    {
        Vector3 pos = maincamera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;

        if (knife)
        {
            if (flipflop)
            {
                if (transform.position.x < 2f)
                {
                    flipflop = false;
                    stage++;
                }
            }
            else
            {
                if (transform.position.x > 2f)
                {
                    flipflop = true;
                    stage++;
                }
            }

            if (stage > 20)
            {
                FindObjectOfType<LevelManager>().progress = 1;
                FindObjectOfType<LevelManager>().chibi.ShowChibi(0, 4);
                bileshadow.SetActive(false);
            }
        }
    }
    void Start()
    {
        maincamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        startPos = transform.position;
    }

    private void OnMouseUp()
    {
        float mesafe = Vector3.Distance(startPos, transform.position);
        
        if (mesafe > 1f)
        {
            Debug.Log(mesafe);
            this.enabled = false;
        }
        else
        {
            transform.position = startPos;
        }
    }
}