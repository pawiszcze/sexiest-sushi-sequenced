using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterJump : Jump
{
    [SerializeField] float jumpDelay;

    new void Start()
    {
        base.Start();
        //body = GetComponent<Rigidbody2D>();
        InvokeRepeating("PerformJump", 1.0f, jumpDelay);
    }
}
