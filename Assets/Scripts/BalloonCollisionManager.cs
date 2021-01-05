using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollisionManager : FallingDown
{
	private int lives = 20;

    // Update is called once per frame
    private void Update()
    {
		if (this.lives <= 0)
		{
			CanvasManager.BalloonsDestroyed++;
			FallDown(false);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.tag == CustomTag.EnemyBalloon.ToString())
		{
			Debug.Log("Gameover");
			this.lives = 0;
		}
	}
}
