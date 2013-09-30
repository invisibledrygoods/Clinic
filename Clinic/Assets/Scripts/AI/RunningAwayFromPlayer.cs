using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class RunningAwayFromPlayer : CircuitComponent
{
    public List<CircuitComponent> Next;
    public float radius = 10.0f;

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
            movement.target = 2 * module.position - t.position;
            movement.target.z = t.position.z;

            if (Vector3.Distance(t.position, module.position) > radius)
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
