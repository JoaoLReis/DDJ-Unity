﻿using UnityEngine;
using System.Collections;
using Includes;

public class FireElementPickup : Pickup
{
    public override void Start()
    {
        if (GameManager.Instance.Stats.lim_primary_fire_level > 0)
            Destroy(transform.parent.gameObject);
        base.Start();
    }
    public override void applyEffect()
    {
        //update PlayerStats to set primary_element_level and lim_element;
        //update Interactions to set element active;
        //update ElementElement to unlock its main weapon;
        playerInteractions.updateActiveElements("fire");
        GameManager.Instance.Stats.lim_points++;
    }
}