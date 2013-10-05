using UnityEngine;
using System.Collections.Generic;
using Require;

public class Walking : CircuitComponent
{
    public List<CircuitComponent> a;
    public List<CircuitComponent> b;
    public List<CircuitComponent> teleport;

    Transform module;
    FollowsTarget movement;
    UsesAxisInput axis;
    UsesButtonInput buttons;
    HasAMailbox mailbox;

    void Awake()
    {
        module = transform.GetModuleRoot();
        movement = module.Require<FollowsTarget>();
        axis = module.Require<UsesAxisInput>();
        buttons = module.Require<UsesButtonInput>();
        mailbox = module.Require<HasAMailbox>();
    }

    void Update()
    {
        movement.target = module.position;

        Vector3 right = -module.right;
        Vector3 forward = -module.forward;
        forward.y = 0;
        forward.Normalize();

        if (axis.Get("Vertical") > 0.1f)
        {
            movement.target += forward;
        }
        
        if (axis.Get("Vertical") < -0.1f)
        {
            movement.target -= forward;
        }
        
        if (axis.Get("Horizontal") > 0.1f)
        {
            movement.target += right;
        }
        
        if (axis.Get("Horizontal") < -0.1f)
        {
            movement.target -= right;
        }

        if (buttons.Released("A"))
        {
            Spark(a);
        }
        else if (buttons.Released("B"))
        {
            Spark(b);
        }

        mailbox.On("teleport to (__, __, __)", _ =>
        {
            // TODO: maybe some central destination component that follows target and teleport both use?

            foreach (Teleporting teleporting in module.GetComponentsInChildren<Teleporting>())
            {
                teleporting.to = new Vector3(_[0], _[1], _[2]);
            }

            Spark(teleport);
        });
    }

    void OnDisable()
    {
        movement.target = module.position;
    }

    void OnDrawGizmos()
    {
        GizmoTurtle turtle = new GizmoTurtle(transform.position);

        turtle.PenUp().Forward(0.3f);
        turtle.PenDown().RotateLeft(90).Forward(0.1f).RotateLeft(90).Forward(0.2f)
            .RotateRight(90).Forward(0.2f).RotateLeft(90).Forward(0.2f).RotateLeft(90).Forward(0.2f)
            .RotateRight(90).Forward(0.2f).RotateLeft(90).Forward(0.2f).RotateLeft(90).Forward(0.2f)
            .RotateRight(90).Forward(0.2f).RotateLeft(90).Forward(0.2f).RotateLeft(90).Forward(0.2f)
            .RotateRight(90).Forward(0.2f).RotateLeft(90).Forward(0.1f);

        DrawWires();
    }
}
