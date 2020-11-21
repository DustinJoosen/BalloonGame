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

    private float timeCounter = 0;
    private float speed = 2;
    private float orbit = 2;

    private bool falling = false;

    private GameObject Player;
    private EnemyStatus enemyStatus = EnemyStatus.Falling;

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

        if (Input.GetKeyDown("d"))
            falling = true;

        if (falling)
            enemyStatus = EnemyStatus.Falling;

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
        timeCounter += Time.deltaTime * speed;

        orbit -= 0.01f;

        float x = Mathf.Cos(timeCounter) * orbit;
        float y = this.transform.position.y - 0.3f;
        float z = Mathf.Sin(timeCounter) * orbit;

        transform.position = new Vector3(this.transform.position.x + x, y, this.transform.position.z + z);

        if (orbit < 0)
            Destroy(gameObject); 
    }

    private bool IsCloseToPlayer()
	{
        float xDiff = Player.transform.position.x - this.transform.position.x;
        float zDiff = Player.transform.position.z - this.transform.position.z;

        return IsBetween(-minDistanceX, minDistanceX, xDiff) && IsBetween(-minDistanceZ, minDistanceZ, zDiff);
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
