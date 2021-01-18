using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
	public void Start()
	{
		Debug.Log("Started");
	}

	public void LoadGame()
	{
		try
		{
			SceneManager.LoadScene("SampleScene");
			Debug.Log("Loading game");
		}
		catch
		{
			Debug.Log("Error");
		}
	}

	public void ExitGame()
	{
		Application.Quit();
		Debug.Log("Quiting game");
	}
}
