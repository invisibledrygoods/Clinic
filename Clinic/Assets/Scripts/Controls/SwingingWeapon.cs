using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class SwingingWeapon : CircuitComponent
{
    public List<CircuitComponent> next;
    public List<CircuitComponent> fail;

    public float startAfterSeconds;
    public float finishAfterSeconds;
    public float recoverAfterSeconds;
    public Transform hitbox;

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
        else if (secondsSinceEnabled > finishAfterSeconds)
        {
            hitbox.gameObject.SetActive(false);
        }
        else if (secondsSinceEnabled > startAfterSeconds)
        {
            hitbox.gameObject.SetActive(true);
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
