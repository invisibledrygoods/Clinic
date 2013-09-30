using UnityEngine;
using System.Collections.Generic;
using Require;

public class WaitingForProximity : CircuitComponent
{
    public List<CircuitComponent> next;
    public Transform triggeredBy;
    public float radius;

    void Update()
    {
        if (Vector3.Distance(triggeredBy.position, transform.position) < radius)
        {
            Spark(next);
        }
    }

    void OnDrawGizmos()
    {
        DrawWires();

        Color old = Gizmos.color;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = old;
    }
}
