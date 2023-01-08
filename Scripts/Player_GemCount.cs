using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_GemCount : MonoBehaviour
{
    public float collectedGems = 0;
    public TextMeshProUGUI gemCounter;


    void Update()
    {
        gemCounter.text = "Gems: " + collectedGems.ToString();
    }
}