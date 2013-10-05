using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class Attacking : CircuitComponent
{
    public List<CircuitComponent> next;

    public float startAfterSeconds;
    public float finishAfterSeconds;
    public float recoverAfterSeconds;
    public Transform hitbox;

    Transform module;
    float secondsSinceEnabled;

    void Awake()
    {
        module = transform.GetModuleRoot();
    }

    void Update()
    {
        secondsSinceEnabled += Time.deltaTime;

        if (secondsSinceEnabled > recoverAfterSeconds)
        {
            Spark(next);
        }
        else if (secondsSinceEnabled > finishAfterSeconds)
        {
            hitbox.gameObject.SetActive(false);
        }
        else if (secondsSinceEnabled > startAfterSeconds)
        {
            hitbox.gameObject.SetActive(true);
        }
    }

    public void OnEnable()
    {
        secondsSinceEnabled = 0;
    }

    public void OnDisable()
    {
        hitbox.gameObject.SetActive(false);
    }

    public void OnDrawGizmos()
    {
        DrawWires();
        DrawLabel();
    }
}
