using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random=UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public Data data;
    public GameObject monsterCarrier;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject monsterHealthBar;
    public TMP_Text levelText;
    public TMP_Text monsterHealthText;
    public TMP_Text monstersLeftText;
    private double monsterHealth;
    public List<GameObject> monsters;

    public void Start()
    {
        foreach (var monster in monsterCarrier.GetComponentsInChildren<RectTransform>()) monsters.Add(monster.gameObject);
        monsters.RemoveAt(0);
        NewSprite();
    }
    public void PreviousLevel()
    {
        if (Controller.instance.data.currentLevel > 1)
        {
            Controller.instance.data.currentLevel -= 1;
            levelText.text = $"Level {Controller.instance.data.currentLevel}";
            monsterHealth = GetMonsterMaxHealth();
            monstersLeftText.gameObject.SetActive(false);
        }
    }
    public void NextLevel() //Checks if at highest level to show remaining monsters
    {
        if (Controller.instance.data.currentLevel < Controller.instance.data.highestLevel)
        {
            Controller.instance.data.currentLevel += 1;
            levelText.text = $"Level {Controller.instance.data.currentLevel}";
            monsterHealth = GetMonsterMaxHealth();
            if (IsHighestLevel()) monstersLeftText.gameObject.SetActive(true);
            else monstersLeftText.gameObject.SetActive(false);
        }
    }
    public void HurtMonster(double damage) //Damages monster for input, kills if monster health < 0
    {
        monsterHealth -= damage;
        monsterHealthText.text = $"{monsterHealth:F2}";
        if (monsterHealth <= 0) KillMonster();
    }
    public void KillMonster() //Reduces remaining monsters, goes to next level if no more monsters, resets monster health
    {
        data = Controller.instance.data;

        GiveGold();
        //TODO: Death Animation

        if (data.monstersLeft > 0 && IsHighestLevel()) data.monstersLeft--;
        if (data.monstersLeft == 0 && IsHighestLevel()) data.highestLevel ++;
        if (data.NextLevelOnClear && data.currentLevel < data.highestLevel) 
        {
            NextLevel();
            if (IsBoss() == 1) data.monstersLeft = 1;
            else data.monstersLeft = 10;
        }
        monsterHealth = GetMonsterMaxHealth(); //TODO: Multiple monster tiles
        NewSprite();
        monstersLeftText.text = $"{data.monstersLeft} Monsters to Next Level";
        if (IsBoss() == 1) monstersLeftText.text = "Boss Level!";
    }
    public double GetMonsterMaxHealth()
    {
        return(10 * (Controller.instance.data.currentLevel 
        + Math.Pow(1.55, Controller.instance.data.currentLevel) * (IsBoss() * 10)));
    }
    public void GiveGold() => Controller.instance.data.gold += GetMonsterMaxHealth()/15;
    public int IsBoss()
    {
        if ((Controller.instance.data.currentLevel) % 10 == 0) return 1;
        return 0;
    }
    public bool IsHighestLevel() {return (Controller.instance.data.currentLevel == Controller.instance.data.highestLevel);}
    public void NewSprite() //WIP
    {
        foreach (var sprite in monsters) sprite.SetActive(false);
        if (IsBoss() == 0)
        {
            monsters[Random.Range(0,2)].SetActive(true);
        }
        else
        {
            monsters[2].SetActive(true);
        }
    }
}