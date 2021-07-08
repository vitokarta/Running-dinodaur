using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public GameObject UI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale==0)
        {
            UI.SetActive(true);


            if(Input.anyKeyDown)
            {
                Time.timeScale = 1;
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                UI.SetActive(false);
            }
        }
    }
}
