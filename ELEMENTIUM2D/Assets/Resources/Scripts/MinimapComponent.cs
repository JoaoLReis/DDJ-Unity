﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Sprite))]
public class MinimapComponent : MonoBehaviour {

    public enum Type { OBSTACLE, PLAYER, ENEMY, SPAWNER, PROP}
    public Type type;

    private Sprite sprite;

	// Use this for initialization
	void Start () {
        SpriteRenderer spRenderer = gameObject.GetComponent<SpriteRenderer>();
        switch (type)
        {
            case Type.OBSTACLE:
                spRenderer.color = Color.white;
                break;
            case Type.PLAYER:
                spRenderer.color = Color.cyan;
                spRenderer.sortingOrder = 1000;
                break;
            case Type.ENEMY:
                spRenderer.color = Color.red;
                break;
            case Type.SPAWNER:
                spRenderer.color = Color.magenta;
                break;
            case Type.PROP:
                spRenderer.color = Color.yellow;
                break;
            default:
                break;
        }
	}
}