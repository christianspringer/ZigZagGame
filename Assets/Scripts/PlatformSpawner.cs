﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platform;
    Vector3 lastPos;
    float size;
    public bool gameOver;


    // Use this for initialization
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for(int i = 0; i<20; i++)
        {
            SpawnPlatforms();
        }

        InvokeRepeating("SpawnPlatforms", 2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnPlatforms()
    {
        int random = Random.Range(0, 7);
        if (random < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);
    }
}
