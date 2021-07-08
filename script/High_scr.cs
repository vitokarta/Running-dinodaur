using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class High_scr : MonoBehaviour
{
    static public float high_score = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GetComponent<Text>().text = "HIGH SCORE\n        " + (int)high_score;
    }
}
