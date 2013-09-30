using UnityEngine;
using System.Collections;
using Require;

public class RotatesActorWhenSteppedOn : MonoBehaviour
{
    public float angle;
    public float speed;

    void OnTriggerEnter(Collider collider)
    {
        foreach (TweensRotation tween in collider.transform.GetModuleRoot().GetComponents<TweensRotation>())
        {
            tween.angle = angle;
            tween.speed = speed;
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
