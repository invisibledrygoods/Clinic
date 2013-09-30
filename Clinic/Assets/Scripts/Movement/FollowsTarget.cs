using UnityEngine;
using System.Collections;
using Require;

public class FollowsTarget : MonoBehaviour
{
    public Vector3 target;
    public float speed = 1.0f;

    void Update()
    {
        float distance = Vector3.Distance(target, transform.position);

        if (distance < speed * Time.deltaTime)
        {
            transform.position = target;
        }
        else
        {
            Vector3 direction = (target - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
