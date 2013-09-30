using UnityEngine;
using System.Collections;
using Require;

public class ChangesCameraWhenSteppedOn : MonoBehaviour
{
    public Vector3 cameraPosition;
    public Vector3 lookAtOffset;
    public float speed;

    void OnTriggerEnter(Collider collider)
    {
        foreach (Camera camera in collider.transform.GetComponentsInModule<Camera>())
        {
            foreach (TweensCamera tween in camera.GetComponents<TweensCamera>())
            {
                tween.target = cameraPosition;
                tween.lookAtOffsetTarget = lookAtOffset;
                tween.speed = speed;
            }
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
