using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class HasCommandQueue : MonoBehaviour
{
    Queue<ICommand> commands;

    public void Awake()
    {
        commands = new Queue<ICommand>();
    }

    public void Issue(ICommand command)
    {
        commands.Enqueue(command);
    }

    public bool Exist()
    {
        return commands.Count > 0;
    }

    public bool Empty()
    {
        return commands.Count == 0;
    }

    public ICommand Take()
    {
        return commands.Dequeue();
    }
}
