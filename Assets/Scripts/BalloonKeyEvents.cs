using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonKeyEvents : MonoBehaviour
{
    public GameObject Balloon;
    public float MetersPerFrame = 0.5f;

    private float X;
    private float Y;
    private float Z;

    private bool IsPressingLeft = false;
    private bool IsPressingRight = false;
    private bool IsPressingUp = false;
    private bool IsPressingDown = false;
   

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started game");

        X = Balloon.transform.position.x;
        Y = Balloon.transform.position.y;
        Z = Balloon.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        IsPressingLeft = Input.GetKeyDown(KeyCode.LeftArrow) ? true : IsPressingLeft;
        IsPressingLeft = Input.GetKeyUp(KeyCode.LeftArrow) ? false : IsPressingLeft;

        IsPressingRight = Input.GetKeyDown(KeyCode.RightArrow) ? true : IsPressingRight;
        IsPressingRight = Input.GetKeyUp(KeyCode.RightArrow) ? false : IsPressingRight;

        IsPressingUp = Input.GetKeyDown(KeyCode.UpArrow) ? true : IsPressingUp;
        IsPressingUp = Input.GetKeyUp(KeyCode.UpArrow) ? false : IsPressingUp;

        IsPressingDown = Input.GetKeyDown(KeyCode.DownArrow) ? true : IsPressingDown;
        IsPressingDown = Input.GetKeyUp(KeyCode.DownArrow) ? false : IsPressingDown;

        if (IsPressingLeft)
            X -= MetersPerFrame;

        if (IsPressingRight)
            X += MetersPerFrame;

        if (IsPressingUp)
            Z += MetersPerFrame;

        if (IsPressingDown)
            Z -= MetersPerFrame;

        Balloon.transform.position = new Vector3(X, Y, Z);
    }
}
