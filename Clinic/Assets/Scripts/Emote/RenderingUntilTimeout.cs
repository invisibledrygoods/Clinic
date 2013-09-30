using UnityEngine;
using System.Collections.Generic;
using Require;

public class RenderingUntilTimeout : CircuitComponent
{
    public List<CircuitComponent> next;

    public float duration = 5.0f;

    float timeout;

    void Update()
    {
        timeout -= Time.deltaTime;

        if (timeout < 0)
        {
            Spark(next);
        }
    }

    void OnEnable()
    {
        timeout = duration;

        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = true;
        }
    }

    void OnDisable()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }
    }

    void OnDrawGizmos()
    {
        Color old = Gizmos.color;
        Gizmos.color = Color.cyan;
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            Gizmos.DrawWireCube(renderer.bounds.center, renderer.bounds.size);
        }
        Gizmos.color = old;

        DrawWires();
    }
}
