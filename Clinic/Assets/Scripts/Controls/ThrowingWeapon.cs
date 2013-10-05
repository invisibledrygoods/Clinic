using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class ThrowingWeapon : CircuitComponent
{
    public List<CircuitComponent> next;
    public List<CircuitComponent> fail;

    public float releaseAfterSeconds;
    public float recoverAfterSeconds;

    Transform module;
    Transform carriedWeapon;
    float secondsSinceEnabled;

    void Awake()
    {
        module = transform.GetModuleRoot();
    }

    void Update()
    {
        secondsSinceEnabled += Time.deltaTime;

        // TODO: hitbox needs to have its stats changed to match weapon

        if (secondsSinceEnabled > recoverAfterSeconds)
        {
            Spark(next);
        }
        else if (secondsSinceEnabled > releaseAfterSeconds)
        {
            carriedWeapon.localPosition = module.position + Vector3.up;
            carriedWeapon.transform.parent = null;
            carriedWeapon.Require<HasAMailbox>().Send("you were thrown");
        }
    }

    void OnEnable()
    {
        secondsSinceEnabled = 0.0f;
        carriedWeapon = null;

        foreach (IsAWeapon weapon in module.GetComponentsInChildren<IsAWeapon>())
        {
            carriedWeapon = weapon.transform;
        }

        if (carriedWeapon == null)
        {
            Spark(fail);
        }
    }

    void OnDrawGizmos()
    {
        DrawWires();
        DrawLabel();
    }
}
