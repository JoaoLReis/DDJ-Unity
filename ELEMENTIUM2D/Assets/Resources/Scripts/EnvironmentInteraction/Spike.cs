﻿using UnityEngine;
using System.Collections;
using Includes;

public class Spike : BreakableProp
{
    public float damage = 2.0f;
    private Animator animator;
    // Use this for initialization
    void Start()
    {
        maxDurability = 10;
        durability = maxDurability;
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("Triggered", false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void resetTrigger()
    {
        animator.SetBool("Triggered", false);
    }

    void OnTriggerEnter(Collider col)
    {
        if ((LayerMask.NameToLayer("Player") == col.gameObject.layer || LayerMask.NameToLayer("Enemy") == col.gameObject.layer) && !animator.GetBool("Triggered"))
        {
            animator.SetBool("Triggered", true);
            Invoke("resetTrigger", 1.4f);
            col.gameObject.GetComponent<Agent>().takeDamage(damage, Elements.NEUTRAL, false);
        }
    }

    /*void OnTriggerExit(Collider col)
    {
        if ((LayerMask.NameToLayer("Player") == col.gameObject.layer || LayerMask.NameToLayer("Enemy") == col.gameObject.layer) && !animator.GetBool("Triggered"))
        {
            animator.SetBool("Triggered", true);
            Invoke("resetTrigger", 0.4f);
            col.gameObject.GetComponent<Agent>().takeDamage(damage, Elements.NEUTRAL, true);
        }
    }*/
}