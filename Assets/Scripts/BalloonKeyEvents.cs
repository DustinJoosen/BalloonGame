using Assets.Scripts.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonKeyEvents : MonoBehaviour
{
    public float metersPerFrame = 0.5f;
    public static float shiftMetersPerFrame;

    public float shiftSpeed = 3.0f;

    private static float x;
    private static float y;
    private static float z;

    private static bool isPressingShift = false;

    public KeyEventHandler keyEventHandler = new KeyEventHandler();
	public delegate void MovingAction(KeyCode keyEvent);

    // Start is called before the first frame update
    void Start()
    {
        MovingAction movingHandler = HandleMovement;

        keyEventHandler.AddEventHandler(new KeyEvent(KeyCode.LeftArrow, movingHandler));
        keyEventHandler.AddEventHandler(new KeyEvent(KeyCode.RightArrow, movingHandler));
        keyEventHandler.AddEventHandler(new KeyEvent(KeyCode.UpArrow, movingHandler));
        keyEventHandler.AddEventHandler(new KeyEvent(KeyCode.DownArrow, movingHandler));
        keyEventHandler.AddEventHandler(new KeyEvent(KeyCode.LeftShift, movingHandler));

        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;

        Debug.Log("Started game");

    }

    // Update is called once per frame
    void Update()
    {
        shiftMetersPerFrame = metersPerFrame;
        if (isPressingShift)
            shiftMetersPerFrame *= shiftSpeed;

        keyEventHandler.CheckKeyEvents();
        this.transform.position = new Vector3(x, y, z);
    }

    public static void HandleMovement(KeyCode keyCode)
	{
        isPressingShift = keyCode == KeyCode.LeftShift;

        switch (keyCode)
		{
            case KeyCode.LeftArrow:
                x -= shiftMetersPerFrame;
                break;
            case KeyCode.RightArrow:
                x += shiftMetersPerFrame;
                break;
            case KeyCode.UpArrow:
                z += shiftMetersPerFrame;
                break;
            case KeyCode.DownArrow:
                z -= shiftMetersPerFrame;
                break;
            default:
                break;
		}

	}

}
