using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Assets.Scripts.Helpers;
using System.Linq;

public class EnemyMoving : MonoBehaviour
{

    public int MaxTicks = 300;

    public int minDistanceX = 100;
    public int minDistanceZ = 100;

    private int xTicks;
    private int zTicks;

    private float xDir;
    private float zDir;

    private GameObject Player;
    private EnemyStatus enemyStatus = EnemyStatus.Following;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PlayerBalloon");

        SetxDirections();
        SetzDirections();
    }

    // Update is called once per frame
    void Update()
    {
        enemyStatus = IsCloseToPlayer() ? EnemyStatus.Following : EnemyStatus.MovingRandom;

        switch (enemyStatus)
        {
            case EnemyStatus.MovingRandom:
                MovingRandom();
                break;
            case EnemyStatus.Following:
                Follow();
                break;
            case EnemyStatus.Falling:
                Falling();
                break;
        }

    }

    private void MovingRandom()
	{
        xTicks--;
        zTicks--;

        if (xTicks <= 0)
            SetxDirections();

        if (zTicks <= 0)
            SetzDirections();

        this.transform.position = new Vector3()
        {
            x = this.transform.position.x + xDir,
            y = this.transform.position.y,
            z = this.transform.position.z + zDir,
        };

    }
    private void Follow()
	{
        float x = this.transform.position.x;
        float z = this.transform.position.z;

        x += (this.Player.transform.position.x > x) ? 0.1f : -0.1f;
        z += (this.Player.transform.position.z > z) ? 0.1f : -0.1f;

        this.transform.position = new Vector3()
        {
            x = x,
            y = this.transform.position.y,
            z = z,
        };
    }

    private void Falling()
	{
        //Todo: create falling animation
	}

    private bool IsCloseToPlayer()
	{
        float xDiff = Player.transform.position.x - this.transform.position.x;
        float zDiff = Player.transform.position.z - this.transform.position.z;

        return IsBetween(-minDistanceZ, minDistanceZ, zDiff) && IsBetween(-minDistanceX, minDistanceX, xDiff);
	}

    static bool IsBetween(float start, float end, float num)
	{
        return num >= start && num <= end;
	}

    private void SetxDirections()
	{
        xTicks = RandomNum.GetRandom(MaxTicks);
        xDir = ((float)RandomNum.GetRandom(-1, 2)) / 5;
	}
    private void SetzDirections()
    {
        zTicks = RandomNum.GetRandom(MaxTicks);
        zDir = ((float)RandomNum.GetRandom(-1, 2)) / 5;
    }

}
