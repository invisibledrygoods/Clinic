using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class PickingUpWeapon : CircuitComponent
{
    public List<CircuitComponent> next;
    public List<CircuitComponent> no;

    public float pickUpRadius = 1.0f;
    public float giveAfterSeconds;
    public float recoverAfterSeconds;

    Transform module;
    float secondsSinceEnabled;
    Transform closestWeapon;

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
        else if (secondsSinceEnabled > giveAfterSeconds)
        {
            Debug.Log("closest weapon: " + closestWeapon.name);
            closestWeapon.parent = module;
            closestWeapon.localPosition = new Vector3(0, 2, 0);
        }
    }

    void OnEnable()
    {
        secondsSinceEnabled = 0.0f;
        closestWeapon = null;

        new Select(".IsAWeapon").Each<Transform>(t =>
        {
            if (Vector3.Distance(module.position, t.position) < pickUpRadius)
            {
                closestWeapon = t;
            }
        });

        if (closestWeapon == null)
        {
            Spark(no);
        }
    }

    void OnDrawGizmos()
    {
        DrawWires();
        DrawLabel();
    }
}
