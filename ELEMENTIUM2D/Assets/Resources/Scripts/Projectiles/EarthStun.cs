﻿using UnityEngine;
using System.Collections;
using Includes;

public class EarthStun : AbilityBehaviour {

    protected override void Awake()
    {
        explosion = Resources.Load("Prefabs/Explosions/earthExplosion") as GameObject;
        damage = 1;
    }

    protected override void Start()
    {
        base.Start();
        type = Elements.EARTH;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.CompareTo("Enemy") == 0)
        {
            if (collision.gameObject.GetComponent<StunnedStatusEffect>() == null)
            {
                StunnedStatusEffect sse = collision.gameObject.AddComponent<StunnedStatusEffect>();
                sse.setDuration(5.0f);
                sse.applyStatusEffect(collision.gameObject.GetComponent<EnemyScript>());
            }
        }
        if (collidedWith(collision.gameObject, damage)) ;
        else if (collidedWithBreakable(collision.gameObject)) ;
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Unhitable"))
            return;
        base.OnCollisionEnter(collision);
    }


    public override void initiate(GameObject startingObject, float dmg)
    {
        damage = dmg;
        ConstantForce constantForce = gameObject.AddComponent<ConstantForce>();
        constantForce.relativeForce = new Vector3(0.0f, 0.0f, AbilityStats.Earth.ability2.movementForce);
    }
}
