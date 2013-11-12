using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class Flying : CircuitComponent
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
        timeout += Time.deltaTime;
        module.position += velocity * Time.deltaTime;

        if (timeout > 0.5f)
        {
            Spark(next);
        }
    }

    void OnDisable()
    {
        timeout = 0.0f;
    }

    void OnDrawGizmos()
    {
        DrawWires();
        DrawLabel();
    }
}
