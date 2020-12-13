using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Text BalloonsHitLabel;
    public static int BalloonsHit = 0;

    public Text BalloonsDestroyedLabel;
    public static int BalloonsDestroyed = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        BalloonsHitLabel.text = $"Balloons hit: {BalloonsHit}";   
        BalloonsDestroyedLabel.text = $"Balloons destroyed: {BalloonsDestroyed}";   
    }

}
