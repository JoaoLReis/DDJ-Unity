﻿using UnityEngine;
using System.Collections;
using Includes;

public class IceShard : ProjectileBehaviour
{

    protected override void Start()
    {
        base.Start();
        damage = ProjectileStats.Iceshard.damage;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Enemy") == 0)
        {
            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
            enemy.takeDamage(damage, Elements.FROST);
        }
        else if (collision.gameObject.layer != LayerMask.NameToLayer("Unhitable"))
            return;
        base.OnCollisionEnter2D(collision);
    }

    public override void applyMovement()
    {
        ConstantForce2D constantForce = gameObject.AddComponent<ConstantForce2D>();
        constantForce.relativeForce = new Vector2(ProjectileStats.Iceshard.movementForce, 0.0f);
    }
}
