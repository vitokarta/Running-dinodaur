using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state : MonoBehaviour
{
    public float movespeed = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movespeed >18.5f)
            movespeed = -15f - Time.timeSinceLevelLoad * 0.01f;
        else if(movespeed > 17.5f)
            movespeed = -15f - Time.timeSinceLevelLoad * 0.05f;
        else
            movespeed = -15f - Time.timeSinceLevelLoad * 0.1f;

        //Debug.Log(movespeed);
        GetComponent<Transform>().localPosition += new Vector3(movespeed, 0) * Time.deltaTime;
        if(GetComponent<Transform>().localPosition.x < -10)   Destroy(gameObject);

        if (move.Invincible)
            GetComponent<Collider2D>().enabled = false;
        else
            GetComponent<Collider2D>().enabled = true ;
    }
}
