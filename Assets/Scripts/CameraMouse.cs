using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouse : MonoBehaviour
{
    public float HorizontalSpeed = 5.0f;
    public float VerticalSpeed = 5.0f;

    private float HorizontalAlignment = 0.0f;
    private float VerticalAlignment = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalAlignment += HorizontalSpeed * Input.GetAxis("Mouse X");
        VerticalAlignment -= VerticalSpeed * Input.GetAxis("Mouse Y");

        HorizontalAlignment = Mathf.Clamp(HorizontalAlignment, -55f, 55f);
        VerticalAlignment = Mathf.Clamp(VerticalAlignment, -15f, 70f);

        transform.eulerAngles = new Vector3(VerticalAlignment, HorizontalAlignment, 0.0f);
    }
}
