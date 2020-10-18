using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public int AmountBalloons = 3;
    public GameObject BalloonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < AmountBalloons; i++)
		{
            Instantiate(BalloonPrefab, new Vector3(0, 0, 0), Quaternion.Euler(270, 0, 0));
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
