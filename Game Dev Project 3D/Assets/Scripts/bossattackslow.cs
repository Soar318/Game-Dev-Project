﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossattackslow : MonoBehaviour
{

    float xSpeed = 4f;
    Rigidbody myRigidbody;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(-xSpeed, 0);
    }
}
