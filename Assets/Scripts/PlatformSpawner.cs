using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platform;
    public GameObject diamond; 
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
        Vector3 position = lastPos;
        position.x += size;
        lastPos = position;
        Instantiate(platform, position, Quaternion.identity);
        DiamondSpawn(GetDiamondPosition(position));

    }

    void SpawnZ()
    {
        Vector3 position = lastPos;
        position.z += size;
        lastPos = position;
        Instantiate(platform, position, Quaternion.identity);
        DiamondSpawn(GetDiamondPosition(position));


    }

    void DiamondSpawn(Vector3 position)
    {
        int random = Random.Range(0, 4);

        if (random < 1)
        {
            Instantiate(diamond, position, diamond.transform.rotation);
        }
    }

    Vector3 GetDiamondPosition(Vector3 platformPosition)
    {
        return new Vector3(platformPosition.x, platformPosition.y + 1, platformPosition.z);
    }
}
