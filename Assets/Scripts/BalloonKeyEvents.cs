using Assets.Scripts.Helpers;
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

    private static bool isGoingLeft = false;
    private static bool isGoingLeftPrevFrame = false;
    private static bool isSlowingDownToLeft = false;
    private static SpeedPos goingLeftSpeedPos;

    private List<KeyCode> keyCodes;

    private EasedMoving easedMoving = new EasedMoving();

    // Start is called before the first frame update
    void Start()
    {
        genericMetersPerFrame = metersPerFrame;

        keyCodes = new List<KeyCode>(){
            KeyCode.LeftArrow, 
            KeyCode.RightArrow, 
            KeyCode.UpArrow, 
            KeyCode.DownArrow, 
            KeyCode.LeftShift 
        };


        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;

        goingLeftSpeedPos = new SpeedPos(genericMetersPerFrame, x);


        Debug.Log("Started game");

    }

    // Update is called once per frame
    void Update()
    {
        genericMetersPerFrame = isPressingShift ? metersPerFrame * shiftSpeed : metersPerFrame;

        isGoingLeftPrevFrame = isGoingLeft;
        isGoingLeft = false;

        foreach (KeyCode keyCode in keyCodes)
        {
            if (Input.GetKey(keyCode))
                HandleMovement(keyCode);

            if (isGoingLeftPrevFrame && !isGoingLeft || isSlowingDownToLeft)
			{
                isSlowingDownToLeft = true;

                if(goingLeftSpeedPos.Speed <= 0.01)
				{
                    isSlowingDownToLeft = false;
				}

                x = easedMoving.EaseOut(goingLeftSpeedPos);
                goingLeftSpeedPos.Pos = x;
            }

        }

        this.transform.position = new Vector3(x, y, z);
    }

    public static void HandleMovement(KeyCode keyCode)
	{
        isPressingShift = keyCode == KeyCode.LeftShift;

        switch (keyCode)
		{
            case KeyCode.LeftArrow:
                isGoingLeft = true;
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
