using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class FlipsToFaceTarget : MonoBehaviour
{
    Transform module;
    FollowsTarget movement;
    Vector3 lastNonZeroFacing;

    void Awake()
    {
        module = transform.GetModuleRoot();
        movement = module.Require<FollowsTarget>();
    }

    void Update()
    {
        Vector3 facing = module.position - movement.target;
        facing.y = 0.0f;
        facing.z = 0.0f;

        if (facing.magnitude > 0.1f)
        {
            lastNonZeroFacing = facing;
        }

        if (Vector3.Dot(module.right, lastNonZeroFacing) < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
