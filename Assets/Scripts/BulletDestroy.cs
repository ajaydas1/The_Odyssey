﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collide)
    {
        if(collide.gameObject.tag == "Player") Destroy(collide.gameObject);
        Destroy(gameObject);
    }
}
