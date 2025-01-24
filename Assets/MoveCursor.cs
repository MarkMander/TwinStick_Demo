using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MoveCursor : MonoBehaviour
{
    public Camera cam;
    public float cursorScalor = 2.5f;
    private Vector3 playerScreenPos;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        playerScreenPos = cam.WorldToScreenPoint(transform.parent.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        //transform.position = (2.5f / mousePos.magnitude) * mousePos + transform.parent.position;
        angle = Mathf.Atan2(-playerScreenPos.y+mousePos.y,-playerScreenPos.x+mousePos.x);
        transform.position = new Vector3(cursorScalor * Mathf.Cos(angle), cursorScalor*Mathf.Sin(angle), 0)+transform.parent.position;

    }
}
