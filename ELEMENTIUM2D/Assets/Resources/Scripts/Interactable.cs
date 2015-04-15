﻿using UnityEngine;
using System.Collections;
using Includes;

public class Interactable : MonoBehaviour {

    protected GameObject textDisplay;

    void Awake()
    {
        textDisplay = transform.FindChild("InteractionText").gameObject;
        textDisplay.SetActive(false);
    }

    protected void displayText()
    {
        textDisplay.SetActive(true);
        textDisplay.GetComponent<TextMesh>().text = "[F]";
    }

    protected void hideText()
    {
        textDisplay.SetActive(false);
    }

    public virtual void applyEffect() { }

}
