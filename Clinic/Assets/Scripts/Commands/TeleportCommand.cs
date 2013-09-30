using UnityEngine;
using System.Collections.Generic;
using System;
using Require;

public class TeleportCommand : ICommand
{
    public Transform teleporting;
    public Vector3 teleportTo;
    public float speed;

    float alpha;

    public TeleportCommand(Transform teleporting, Vector3 teleportTo, float speed)
    {
        this.teleporting = teleporting;
        this.teleportTo = teleportTo;
        this.speed = speed;
    }

    #region ICommand Members

    public ICommand Start()
    {
        alpha = 0.0f;
        return this;
    }

    public ICommand Update()
    {
        alpha += Time.deltaTime * speed;

        if (alpha > 1.0f)
        {
            teleporting.position = teleportTo;
            new Select(teleporting.gameObject).Each<FollowsTarget>(f => f.target = teleportTo);
            speed = -speed;
            alpha = 1.0f;
        }

        if (speed < 0.0f && alpha < 0.0f)
        {
            return null;
        }

        new Select("#GUI #Fader").Each<Renderer>(r => r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, alpha));

        return this;
    }

    #endregion
}
