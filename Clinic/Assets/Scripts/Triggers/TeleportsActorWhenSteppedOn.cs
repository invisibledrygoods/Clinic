using UnityEngine;
using System.Collections;
using Require;

public class TeleportsActorWhenSteppedOn : MonoBehaviour
{
    public Vector3 teleportTo;
    public float speed = 1.0f;

    void OnTriggerEnter(Collider collider)
    {
        HasCommandQueue commands = collider.transform.GetModuleRoot().GetComponent<HasCommandQueue>();
        if (commands != null)
        {
            commands.Issue(new TeleportCommand(new Select("#Player")[0].transform, teleportTo, speed));
        }
    }

    void OnDrawGizmos()
    {
        Color old = Gizmos.color;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
        Gizmos.color = old;
    }
}
