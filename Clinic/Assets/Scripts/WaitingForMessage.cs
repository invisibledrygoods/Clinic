using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class WaitingForMessage : CircuitComponent
{
    public List<CircuitComponent> next;
    public string message;

    Transform module;
    HasAMailbox mailbox;

    void Awake()
    {
        module = transform.GetModuleRoot();
        mailbox = module.Require<HasAMailbox>();
    }

    void Update()
    {
        mailbox.Read(message, _ => {
            Debug.Log("got a message");
            Spark(next);
        });
    }

    void OnDrawGizmos()
    {
        DrawWires();
        DrawLabel();
    }
}
