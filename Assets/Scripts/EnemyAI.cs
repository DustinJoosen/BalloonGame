using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Assets.Scripts.Helpers;
using System.Linq;
using ExtensionMethods;

public class EnemyAI : FallingDown
{

    private int hp = 10;

    //random moving
    public int MaxTicks = 300;

    public int minDistanceX = 100;
    public int minDistanceZ = 100;

    private int xTicks;
    private int zTicks;

    private float xDir;
    private float zDir;

    private GameObject Player;
    private EnemyStatus enemyStatus = EnemyStatus.MovingRandom;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject.FindGameObjectWithCustomTag(CustomTag.PlayerBalloon);

        SetxDirections();
        SetzDirections();
    }

    // Update is called once per frame
    void Update()
    {
		enemyStatus = IsCloseToPlayer() ? EnemyStatus.Following : EnemyStatus.MovingRandom;
        enemyStatus = this.hp <= 0 ? EnemyStatus.Falling : enemyStatus;

        switch (enemyStatus)
        {
            case EnemyStatus.MovingRandom:
                MovingRandom();
                break;
            case EnemyStatus.Following:
                Follow();
                break;
            case EnemyStatus.Falling:
                FallDown();
                break;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != CustomTag.Munition.ToString())
            return;

        this.hp -= 1;
        Destroy(collision.collider.gameObject);
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
