using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyEvents : MonoBehaviour
{
    public GameObject GameObject;
    public float MetersPerFrame = 0.5f;

    private float X;
    private float Y;
    private float Z;

    private bool IsPressingLeft = false;
    private bool IsPressingRight = false;
    private bool IsPressingUp = false;
    private bool IsPressingDown = false;
    private bool IsPressingShift = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started game");

        X = GameObject.transform.position.x;
        Y = GameObject.transform.position.y;
        Z = GameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float meters_per_frame = MetersPerFrame;

        IsPressingLeft = IsPressingKey(KeyCode.LeftArrow, IsPressingLeft);
        IsPressingRight = IsPressingKey(KeyCode.RightArrow, IsPressingRight);
        IsPressingUp = IsPressingKey(KeyCode.UpArrow, IsPressingUp);
        IsPressingDown = IsPressingKey(KeyCode.DownArrow, IsPressingDown);
        IsPressingShift = IsPressingKey(KeyCode.LeftShift, IsPressingShift);

        if (IsPressingShift)
            meters_per_frame = meters_per_frame * 3;
        
        if (IsPressingLeft)
            X -= meters_per_frame;

        if (IsPressingRight)
            X += meters_per_frame;

        if (IsPressingUp)
            Z += meters_per_frame;

        if (IsPressingDown)
            Z -= meters_per_frame;

        GameObject.transform.position = new Vector3(X, Y, Z);
    }

    private bool IsPressingKey(KeyCode keyCode, bool IsPressing)
	{
        IsPressing = Input.GetKeyDown(keyCode) ? true : IsPressing;
        IsPressing = Input.GetKeyUp(keyCode) ? false : IsPressing;

        return IsPressing;
	}
}
