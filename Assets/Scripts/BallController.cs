﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField]
    private float speed;

    bool started;

    bool gameover;

    Rigidbody rb;
    public GameObject particleEffect;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {
        started = false;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
            }
        }

        //Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameover = true;
            rb.velocity = new Vector3(0, -15f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;
        }

        if (Input.GetMouseButtonDown(0) && !gameover)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "diamond")
        {
            GameObject diamondParticleEffect = Instantiate(particleEffect, collider.gameObject.transform.position, Quaternion.identity);
            Destroy(collider.gameObject);
            Destroy(diamondParticleEffect, 1f);
        }
    }
}
