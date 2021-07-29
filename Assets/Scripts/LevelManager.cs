using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject monsterHealthBar;
    public TMP_Text levelText;
    public TMP_Text monsterHealth;

    public void PreviousLevel()
    {
        if (Controller.instance.data.currentLevel > 0)
        {
            Controller.instance.data.currentLevel -= 1;
            levelText.text = $"Level {Controller.instance.data.currentLevel + 1}";
        }
    }
    public void NextLevel()
    {
        if (Controller.instance.data.currentLevel < Controller.instance.data.highestLevel)
        {
            Controller.instance.data.currentLevel += 1;
            levelText.text = $"Level {Controller.instance.data.currentLevel + 1}";
        }
    }
}
