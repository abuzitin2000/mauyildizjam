using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    private Camera maincamera;
    private Vector2 startPos;

    private void OnMouseDrag()
    {
        Vector3 pos = maincamera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
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