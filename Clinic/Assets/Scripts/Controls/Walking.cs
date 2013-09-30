using UnityEngine;
using System.Collections.Generic;
using Require;

public class Walking : CircuitComponent
{
    public List<CircuitComponent> a;
    public List<CircuitComponent> b;
    public List<CircuitComponent> runCommand;

    Transform module;
    FollowsTarget movement;
    UsesAxisInput axis;
    UsesButtonInput buttons;
    HasCommandQueue commands;

    void Awake()
    {
        module = transform.GetModuleRoot();
        movement = module.Require<FollowsTarget>();
        axis = module.Require<UsesAxisInput>();
        buttons = module.Require<UsesButtonInput>();
        commands = module.Require<HasCommandQueue>();
    }

    void Update()
    {
        if (commands.Exist())
        {
            Spark(runCommand);
            return;
        }

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
            Debug.Log("sparking B");
            Spark(b);
        }
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
