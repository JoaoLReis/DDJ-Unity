﻿using UnityEngine;
using System.Collections;
using Includes;

public class NeutralBouncer : ProjectileBehaviour {

    private float disabledTimer = 0.06f;
    private int numSplit = 0;
    private Transform previousEnemy;

    protected override void Start()
    {
        base.Start();
        damage = AbilityStats.Neutral.ability3.damage;
        Invoke("destroyClone", 6f);
        type = Elements.NEUTRAL;
    }

    void OnCollisionStay(Collision coll)
    {
        base.OnCollisionEnter(coll);
    }

    void instanciateSplittedEnemies(Collision collision)
    {
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        enemy.takeDamage(damage, Elements.NEUTRAL);
        for (int i = 0; i < AbilityStats.Neutral.ability3.splitNumber; i++)
        {
            GameObject forkedObj = (GameObject)Instantiate(this.gameObject, collision.transform.position + transform.forward * ((collision.collider.bounds.size.z + collision.collider.bounds.size.x) / 2.0f), transform.rotation);
            NeutralBouncer scrpt = forkedObj.GetComponent<NeutralBouncer>();
            scrpt.previousEnemy = collision.transform;
            scrpt.disabledTimer = 0;
            scrpt.numSplit++;
            float result = Random.Range(AbilityStats.Neutral.ability3.negativeSplitAngle, AbilityStats.Neutral.ability3.positiveSplitAngle);
            forkedObj.transform.Rotate(new Vector3(0.0f, result, 0.0f));
            //Debug.Log("wtf");
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if (disabledTimer > 0.05f )
        {
            if (collision.gameObject.tag.CompareTo("Enemy") == 0 && numSplit < AbilityStats.Neutral.ability3.numSplits )
            {
                if (previousEnemy != null)
                {
                    if(previousEnemy.GetInstanceID() != collision.gameObject.GetInstanceID())
                    {
                        instanciateSplittedEnemies(collision);
                    }
                }
                else
                {
                    instanciateSplittedEnemies(collision);
                }
            }
            else if (collidedWithBreakable(collision)) ;
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Unhitable"))
                return;
            //Invoke("destroyClone", 0.1f);
            base.OnCollisionEnter(collision);
        }
    }

    void Update()
    {
        disabledTimer += Time.deltaTime;
        Transform child = transform.FindChild("Sprite") as Transform;
        child.transform.Rotate(0.0f, 0.0f, Time.deltaTime * 92.0f);
        transform.Translate(Vector3.forward * Time.deltaTime * AbilityStats.Neutral.ability3.movementForce);
    }

    private void destroyClone()
    {
        Destroy(gameObject);
    }

    public override void applyMovement()
    {
    }
}