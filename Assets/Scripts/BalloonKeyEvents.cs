using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonKeyEvents : MonoBehaviour
{
    public GameObject Balloon;
    public GameObject Oak;

    public float MetersPerFrame = 0.5f;

    private float X;
    private float Z;

    private bool IsPressingLeft = false;
    private bool IsPressingRight = false;
    private bool IsPressingUp = false;
    private bool IsPressingDown = false;
    private bool IsPressingShift = false;

    private bool IsCollisionHappening = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started game");

        X = Balloon.transform.position.x;
        Z = Balloon.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        int key_been_pressed = 0;
        float meters_per_frame = MetersPerFrame;

        IsPressingLeft = IsPressingKey(KeyCode.LeftArrow, IsPressingLeft);
        IsPressingRight = IsPressingKey(KeyCode.RightArrow, IsPressingRight);
        IsPressingUp = IsPressingKey(KeyCode.UpArrow, IsPressingUp);
        IsPressingDown = IsPressingKey(KeyCode.DownArrow, IsPressingDown);
        IsPressingShift = IsPressingKey(KeyCode.LeftShift, IsPressingShift);


        if (IsPressingShift) 
            meters_per_frame = meters_per_frame * 3;

        if (IsPressingLeft)
		{
            if(!CollisionFinder.IsColliding(this.Balloon, this.Oak))
			{
                X -= meters_per_frame;
                key_been_pressed++;
            }
		}

        if (IsPressingRight)
		{
            if(!CollisionFinder.IsColliding(this.Balloon, this.Oak))
			{
                X += meters_per_frame;
                key_been_pressed++;
            }

        }

        if (IsPressingUp)
        {
            if(!CollisionFinder.IsColliding(this.Balloon, this.Oak))
			{
                Z += meters_per_frame;
                key_been_pressed++;
            }

        }

        if (IsPressingDown)
		{
            if (!CollisionFinder.IsColliding(this.Balloon, this.Oak))
            {
                Z -= meters_per_frame;
                key_been_pressed++;
            }
        }

        if (key_been_pressed > 1)
            Debug.Log("Pressed multiple keys");

        Balloon.transform.position = new Vector3()
        {
            x = X,
            y = Balloon.transform.position.y,
            z = Z
        };
    }

	private void OnTriggerEnter(Collider other)
	{
        IsCollisionHappening = true;
        Debug.Log("Balloon entered collision");
	}

	private void OnTriggerExit(Collider other)
	{
        IsCollisionHappening = false;
        Debug.Log("Balloon left the collision");
	}

	private bool IsPressingKey(KeyCode keyCode, bool IsPressing)
	{
        IsPressing = Input.GetKeyDown(keyCode) ? true : IsPressing;
        IsPressing = Input.GetKeyUp(keyCode) ? false : IsPressing;

        return IsPressing;
	}

}
