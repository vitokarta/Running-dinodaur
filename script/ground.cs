using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<Transform>().localPosition += new Vector3(-10f, 0) * Time.deltaTime;
        if (GetComponent<Transform>().localPosition.x < -10)
        {
            Instantiate(gameObject, transform.position,transform.rotation);
            Destroy(gameObject);
        } 
    }
}
