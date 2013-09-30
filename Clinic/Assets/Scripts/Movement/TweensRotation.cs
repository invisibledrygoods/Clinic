using UnityEngine;
using System.Collections;
using Require;

public class TweensRotation : MonoBehaviour
{
    public float angle;
    public float speed;

    Transform module;

    void Awake()
    {
        module = transform.GetModuleRoot();
    }

    void Start()
    {
        module.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }

    void Update()
    {
        module.rotation = Quaternion.Lerp(module.rotation, Quaternion.AngleAxis(angle, Vector3.up), Time.deltaTime * speed);
    }
}
