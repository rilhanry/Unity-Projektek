﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private float health = 500f;
    private float score = 0;
    public float shootTime = 0.3f;
    public float lastShootTime = 0;

    public float PlayerHealth { get { return health; } set { health = value; } }
    public float Score { get { return score; } set { score = value; } }

    private GvrReticlePointer aimCross;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lastShootTime > Time.time - shootTime) {
            return;        
        }
        var target = aimCross.CurrentRaycastResult;
        if (target.gameObject) {
            if (target.gameObject.tag == "Enemy") {
                Fire();
                lastShootTime = Time.time;
            }
        }
    }


    void Fire() { 
    }
}
