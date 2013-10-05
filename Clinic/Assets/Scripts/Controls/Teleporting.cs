using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class Teleporting : CircuitComponent
{
    public List<CircuitComponent> next;
    public float speed;
    public Vector3 to;

    Transform module;
    float alpha;
    float direction;

    void Awake()
    {
        module = transform.GetModuleRoot();
    }

    void OnEnable()
    {
        alpha = 0.0f;
        direction = 1.0f;
    }

    void Update()
    {
        alpha += Time.deltaTime * speed * direction;

        if (alpha > 1.0f)
        {
            module.position = to;
            new Select(module.gameObject).Each<FollowsTarget>(movement => movement.target = to);
            direction = -1.0f;
            alpha = 1.0f;
        }

        if (direction < 0.0f && alpha < 0.0f)
        {
            Spark(next);
        }

        new Select("#GUI #Fader").Each<Renderer>(r => r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, alpha));
    }

    void OnDrawGizmos()
    {
        DrawWires();
        DrawLabel();
    }
}
