using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class RunsCommands : CircuitComponent
{
    public List<CircuitComponent> next;

    Transform module;
    HasCommandQueue commands;
    ICommand activeCommand;

    void Awake()
    {
        module = transform.GetModuleRoot();
        commands = module.Require<HasCommandQueue>();
    }

    void Update()
    {
        while (activeCommand == null)
        {
            if (commands.Empty())
            {
                Spark(next);
                return;
            }

            activeCommand = commands.Take().Start();
        }

        activeCommand = activeCommand.Update();
    }

    void OnDrawGizmos()
    {
        DrawWires();
        DrawLabel();
    }
}
