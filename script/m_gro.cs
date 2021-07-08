using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_gro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().localPosition += new Vector3(-10f , 0) * Time.deltaTime;
        if (GetComponent<Transform>().localPosition.x < -10)
        {
            Instantiate(gameObject, new Vector3(10f, -3.84f, 0), transform.rotation);
            Destroy(gameObject);
        }
    }
}
