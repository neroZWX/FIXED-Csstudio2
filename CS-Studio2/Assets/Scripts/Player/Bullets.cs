﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int speed = 5;
    private Rigidbody rgd;
    // Start is called before the first frame update
    void Start()
    {
        rgd = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rgd.MovePosition(transform.position+ transform.forward * speed * Time.deltaTime);
        
    }
}