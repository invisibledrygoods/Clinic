using UnityEngine;
using System.Collections;
using Require;

public class TeleportsActorWhenSteppedOn : MonoBehaviour
{
    public Vector3 teleportTo;
    public float speed = 1.0f;

    void OnTriggerEnter(Collider collider)
    {
        collider.transform.GetModuleRoot().Require<HasAMailbox>().Send("teleport to " + teleportTo);
    }

    void OnDrawGizmos()
    {
        Color old = Gizmos.color;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
        Gizmos.color = old;
    }
}
