﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Includes;
using System;

public class DisplayMultiplier : MonoBehaviour {

    private Text text;

    private Func<int> getCurrentMultiplier = () => { return GameManager.Instance.Stats.currentMultiplier; };

    private int baseFontSize = 12;
    private int fontSizeInc = 3;
    
    private Color[] colors = { Color.white, Color.blue, Color.yellow, Color.red };

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "";
        text.fontSize = baseFontSize;
    }

	void OnGUI()
    {
        int multiplier = getCurrentMultiplier();
        if (multiplier == 0)
            text.text = "";
        else
        {
            int i = PlayerStats.multiplierLevelIndex();

            text.color = colors[i];
            text.fontSize = baseFontSize + fontSizeInc * (i * 2 + 1);
            
            //if (multiplier > GameManager.Instance.Stats.multiplierLevels[0])
            //{
            //    text.color = Color.blue;
            //    text.fontSize = baseFontSize + fontSizeInc;
            //}
            //if (multiplier > GameManager.Instance.Stats.multiplierLevels[1])
            //{
            //    text.color = Color.yellow;
            //    text.fontSize = baseFontSize + fontSizeInc*2;
            //}
            //if (multiplier > GameManager.Instance.Stats.multiplierLevels[2])
            //{
            //    text.color = Color.red;
            //    text.fontSize = baseFontSize + fontSizeInc * 5;
            //}
            text.text = multiplier + " X";
        }
    }
}