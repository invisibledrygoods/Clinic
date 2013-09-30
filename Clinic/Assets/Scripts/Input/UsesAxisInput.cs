using UnityEngine;
using System.Collections;
using Require;

public class UsesAxisInput : MonoBehaviour
{
    public virtual float Get(string axisName)
    {
        return Input.GetAxis(axisName);
    }
}
