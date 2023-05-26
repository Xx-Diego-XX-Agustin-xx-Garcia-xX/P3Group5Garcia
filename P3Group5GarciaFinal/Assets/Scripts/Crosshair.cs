using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D crosshair;
    private int cursorWidth = 32;
    private int cursorHeight = 32;
    private Transform myTransform;
    private Camera myCamera;
    public float xOffset = 10;
    public float yOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        myTransform = transform;    //So you don't GetComponent your transform with every OnGUI call
    }

    private void OnGUI()
    {
        Vector3 screenPos = myCamera.WorldToScreenPoint(myTransform.position);
        screenPos.y = Screen.height - screenPos.y; //The y coordinate on screenPos is inverted so we need to set it straight
        GUI.DrawTexture(new Rect(screenPos.x - xOffset, screenPos.y + yOffset, cursorWidth, cursorHeight), crosshair);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
