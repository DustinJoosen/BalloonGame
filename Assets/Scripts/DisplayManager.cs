using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayManager : MonoBehaviour, IPointerClickHandler
{
    //TP -> Top perspective
    //FP -> First person
    private bool IsFirstPerson
	{
        get => PlayerPrefs.GetString("Camera") == "FP";
        set => PlayerPrefs.SetString("Camera", value ? "FP" : "TP");
	}
    
    // Start is called before the first frame update
    void Start()
    {
        IsFirstPerson = PlayerPrefs.GetString("Camera") == "FP";
    }

	public void SetFirstPersonCamera()
	{
        if (IsFirstPerson)
            return;

        IsFirstPerson = true;
        Debug.Log("Trigger display changes");
    }

    public void SetTopPerspectiveCamera()
	{
        if (!IsFirstPerson)
            return;

        IsFirstPerson = false;
        Debug.Log("Trigger display changes");
    }

	public void OnPointerClick(PointerEventData eventData)
	{
        Debug.Log("pointer clicked");
	}
}
