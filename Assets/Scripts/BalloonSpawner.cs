using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public int AmountBalloons = 3;
    public GameObject BalloonPrefab;

	private readonly int border = 400;

    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < AmountBalloons; i++)
		{
			Instantiate(BalloonPrefab, new Vector3(RandomNum.GetRandom(-border, border), 0, RandomNum.GetRandom(-border, border)), Quaternion.Euler(270, 0, 0));
		}
	}

}
