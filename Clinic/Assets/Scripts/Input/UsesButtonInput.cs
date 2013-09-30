using UnityEngine;
using System.Collections.Generic;
using Require;

public class UsesButtonInput : MonoBehaviour
{
    public virtual bool Pressed(string button)
    {
        return Input.GetButtonDown(button);
    }

    public virtual bool Released(string button)
    {
        return Input.GetButtonDown(button);
    }

    public virtual bool Held(string button)
    {
        return Input.GetButtonDown(button);
    }
}
