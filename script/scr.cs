using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{
    public Color[] list;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay2D(Collision2D other)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = list[0];
    }

    void OnCollisionExit2D(Collision2D other)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = list[1];
    }
}
