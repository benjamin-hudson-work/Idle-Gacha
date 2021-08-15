using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    private void Awake() => instance = this;

    public Data data;
    public UpgradesManager upgradesManager;
    public LevelManager levelmanager;
    public PrestigeTree prestigetree;
    public TMP_Text goldtext;
    public TMP_Text goldclickpowertext;
    public TMP_Text goldpersecondtext;
    public TMP_Text prestigeButton;

    public double ClickPower()   //click
    {
        double total = 1;
        for (int i = 0; i < data.clickUpgradeLevel.Count; i++)
            total += upgradesManager.clickUpgradeBasePower[i] * data.clickUpgradeLevel[i] * SubUpgradePower(i);
        return total;
    }

    public double GoldPerSecond()  //passive
    {
        double total = 0;
        for (int i = 0; i < data.passiveUpgradeLevel.Count; i++)
            total += upgradesManager.passiveUpgradeBasePower[i] * data.passiveUpgradeLevel[i] * SubUpgradePower(i);
        return total;
    }
    public double SubUpgradePower(int index)
    {
        double total = 1;
        for (int i = 0; i < 4; i++)
            total = total + upgradesManager.subUpgradeBasePower[index, i] * data.subUpgradeLevel[index, i];
        return total;
    }

    public float SaveTime;
    private const string dataFileName = "PlayerData_Tutorial";
    public void Start()
    {
        data = SaveSystem.SaveExists(dataFileName) 
            ? SaveSystem.LoadData<Data>(dataFileName) 
            : new Data();

        upgradesManager.StartUpdateManager();
        prestigetree.StartPrestigeTree();
    }

    private double damage;
    public void Update()
    {
        goldtext.text = $"{data.gold:F2} gold"; 
        goldclickpowertext.text = "+" + ClickPower() + " Damage per Click";
        goldpersecondtext.text = $"{GoldPerSecond():F2}/s";

        levelmanager.HurtMonster(GoldPerSecond() * Time.deltaTime);

        SaveTime += Time.deltaTime * (1 / Time.timeScale);
        if (SaveTime >= 15 && data.AutoSave)
        {
            SaveSystem.SaveData(data, dataFileName);
            SaveTime = 0;
        }
    }

    public void EarnGold()
    {
        levelmanager.HurtMonster(ClickPower());
    }
    public void Prestige()
    {
        data.ResetData();
        levelmanager.monstersLeftText.text = $"{data.monstersLeft} Monsters to Next Level";
        levelmanager.InitiateLevel();
        data.prestigePoints++; //WIP
        prestigeButton.text = $"Currently {data.prestigePoints} Prestige points, multiplying DPS by 0%.";
    }
}
