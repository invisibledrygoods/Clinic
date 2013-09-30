using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class RunningTowardsPlayer : CircuitComponent
{
    public List<CircuitComponent> Next;
    public float radius = 3.0f;

    Transform module;
    FollowsTarget movement;

    void Awake()
    {
        module = transform.GetModuleRoot();
        movement = module.Require<FollowsTarget>();
    }

    void Update()
    {
        new Select("#Player").Each<Transform>(t =>
        {
            movement.target = t.position;
            if (Vector3.Distance(t.position, module.position) < radius)
            {
                movement.target = transform.position;
                Spark(Next);
            }
        });
    }

    void OnDrawGizmos()
    {
        DrawWires();
        DrawLabel();
    }
}
