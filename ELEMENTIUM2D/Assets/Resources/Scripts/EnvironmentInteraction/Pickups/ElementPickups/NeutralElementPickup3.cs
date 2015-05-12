﻿using UnityEngine;
using System.Collections;
using Includes;

public class NeutralElementPickup3 : Pickup
{
    public override void Start()
    {
        if (GameManager.Instance.Stats.terciary_neutral_level > 0)
            Destroy(transform.parent.gameObject);
        base.Start();
    }
    public override void applyEffect()
    {
        //update PlayerStats to set primary_element_level and lim_element;
        //update Interactions to set element active;
        //update ElementElement to unlock its main weapon;
        playerInteractions.updateActiveElements("terciary_neutral");
        GameManager.Instance.Stats.lim_points++;
        Destroy(transform.parent.gameObject);
    }
}