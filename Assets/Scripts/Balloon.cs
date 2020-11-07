using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Balloon is loaded");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
        Debug.Log("Entered collision");
	}

	private void OnCollisionExit(Collision collision)
	{
        Debug.Log("Exited collision");
	}
}
