using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class Bouncing : CircuitComponent
{
    public List<CircuitComponent> next;
    public Vector3 velocity;

    float timeout;
    Transform module;

    void Awake()
    {
        module = transform.GetModuleRoot();
    }

    void Update()
    {
        module.position += velocity * Time.deltaTime;

        if (module.position.y < 0)
        {
            Vector3 position = module.position;
            position.y = 0;
            module.position = position;
            Spark(next);
        }
    }

    void OnDrawGizmos()
    {
        DrawWires();
        DrawLabel();
    }
}
