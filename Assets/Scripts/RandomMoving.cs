using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Assets.Scripts.Helpers;

public class RandomMoving : MonoBehaviour
{

    //TODO: make the x and y axis have their own tickspeed

    public int MaxTicks = 300;
    private int ticks;

    private float xDir;
    private float zDir;
    

    // Start is called before the first frame update
    void Start()
    {
        SetDirections();
    }

    // Update is called once per frame
    void Update()
    {
        ticks--;
        if (ticks <= 0)
            SetDirections();

        this.transform.position = new Vector3()
        {
            x = this.transform.position.x + xDir,
            y = this.transform.position.y,
            z = this.transform.position.z + zDir,
        };

    }

    private void SetDirections()
	{
        ticks = RandomNum.GetRandom(MaxTicks);

        xDir = ((float)RandomNum.GetRandom(-1, 2)) / 5;
        zDir = ((float)RandomNum.GetRandom(-1, 2)) / 5;
	}

}
