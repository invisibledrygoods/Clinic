using UnityEngine;
using System.Collections;
using Require;

public class TweensCamera : MonoBehaviour
{
    public Vector3 target;
    public Vector3 lookAtOffsetTarget;
    public float speed;

    Transform module;

    Vector3 lookAtOffset;

    void Awake()
    {
        module = transform.GetModuleRoot();
    }

    void Start()
    {
        transform.localPosition = target;
        lookAtOffset = lookAtOffsetTarget;
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * speed);
        lookAtOffset = Vector3.Lerp(lookAtOffset, lookAtOffsetTarget, Time.deltaTime * speed);

        transform.LookAt(module.position + lookAtOffset);
    }
}
