using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] enemy;
    void Start()
    {
        spawntime = Random.Range(8f, 12f);
    }

    private float ftime = 2.3f;
    private float ftime2 = 0f;
    private float spawntime ;
    void Update()
    {
        if (true)
        {
            ftime += Time.deltaTime;
            if (ftime >= 2.5f - Time.timeSinceLevelLoad * 0.05f)//想间隔的时间
            {
                //在这里塞代码，愿意塞什么就塞什么
                int x = Random.Range(0, 2);
                Instantiate(enemy[x], enemy[x].transform.position, enemy[x].transform.rotation);
                ftime = 0f;//计时器复位
            }
        }

        if (true)
        {
            ftime2 += Time.deltaTime;
            if (ftime2 >= spawntime)//想间隔的时间
            {
                //在这里塞代码，愿意塞什么就塞什么
                int x = Random.Range(0, 2);
                Instantiate(enemy[2], enemy[2].transform.position, enemy[2].transform.rotation);
                ftime2 = 0f;//计时器复位
                spawntime = Random.Range(8, 12);
            }
        }
    }
}