using UnityEngine;
using System.Collections;
using Require;

public class StaysGrounded : MonoBehaviour
{
    void Update()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(new Ray(transform.position + Vector3.up, -Vector3.up), out hitInfo))
        {
            transform.position = hitInfo.point;
        }
    }
}
