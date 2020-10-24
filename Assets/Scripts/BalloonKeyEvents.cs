﻿using Assets.Scripts.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonKeyEvents : MonoBehaviour
{
    public float metersPerFrame = 0.5f;
    public static float genericMetersPerFrame;

    public float shiftSpeed = 3.0f;

    private static float x;
    private static float y;
    private static float z;

    private static bool isPressingShift = false;

    public KeyEventHandler keyEventHandler = new KeyEventHandler();
	public delegate void KeyAction(KeyCode keyEvent);

    // Start is called before the first frame update
    void Start()
    {
        KeyAction actionHandler = HandleMovement;

        keyEventHandler.AddEventHandler(new KeyEvent(KeyCode.LeftArrow, actionHandler));
        keyEventHandler.AddEventHandler(new KeyEvent(KeyCode.RightArrow, actionHandler));
        keyEventHandler.AddEventHandler(new KeyEvent(KeyCode.UpArrow, actionHandler));
        keyEventHandler.AddEventHandler(new KeyEvent(KeyCode.DownArrow, actionHandler));
        keyEventHandler.AddEventHandler(new KeyEvent(KeyCode.LeftShift, actionHandler));

        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;

        Debug.Log("Started game");

    }

    // Update is called once per frame
    void Update()
    {
        genericMetersPerFrame = metersPerFrame;
        if (isPressingShift)
            genericMetersPerFrame *= shiftSpeed;

        keyEventHandler.CheckKeyEvents();
        this.transform.position = new Vector3(x, y, z);
    }

    public static void HandleMovement(KeyCode keyCode)
	{
        isPressingShift = keyCode == KeyCode.LeftShift;

        switch (keyCode)
		{
            case KeyCode.LeftArrow:
                x -= genericMetersPerFrame;
                break;
            case KeyCode.RightArrow:
                x += genericMetersPerFrame;
                break;
            case KeyCode.UpArrow:
                z += genericMetersPerFrame;
                break;
            case KeyCode.DownArrow:
                z -= genericMetersPerFrame;
                break;
            default:
                break;
		}

	}

}
