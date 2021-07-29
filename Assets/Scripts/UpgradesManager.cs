using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager instance;
    private void Awake() => instance = this;

    public Controller controller;
    public Data data;

    public List<Upgrades> clickUpgrades;
    public Upgrades clickUpgradePrefab;

    public List<Upgrades> passiveUpgrades;
    public Upgrades passiveUpgradePrefab;

    public ScrollRect clickUpgradesScroll;
    public GameObject clickUpgradesPanel;

    public ScrollRect passiveUpgradesScroll;
    public GameObject passiveUpgradesPanel;

    public string[] clickUpgradeNames;
    public string[] passiveUpgradeNames;

    public double[] clickUpgradeBaseCost;
    public double[] clickUpgradeMultiplier;
    public double[] clickUpgradeBasePower;

    public double[] passiveUpgradeBaseCost;
    public double[] passiveUpgradeMultiplier;
    public double[] passiveUpgradeBasePower;

    public void StartUpdateManager()
    {
        data = Controller.instance.data;
        Methods.UpgradeCheck(ref data.clickUpgradeLevel, 3); 

        clickUpgradeNames = new[] {"Click Power +1", "Click Power +5", "Click Power +10"};
        passiveUpgradeNames = new[] {"+1 GpS", "+2 GpS", "+10 GpS"};

        clickUpgradeBaseCost = new double[] {10, 50, 100};
        clickUpgradeMultiplier = new double[] {1.25, 1.35, 1.55};
        clickUpgradeBasePower = new double[] {1, 5, 10};

        passiveUpgradeBaseCost = new double[] {25, 100, 1000};
        passiveUpgradeMultiplier = new double[] {1.5, 1.79, 2};
        passiveUpgradeBasePower = new double[] {1, 2, 10};

        for (int i = 0; i < data.clickUpgradeLevel.Count; i++)
        {
            Upgrades upgrade = Instantiate(clickUpgradePrefab, clickUpgradesPanel.transform);
            upgrade.UpgradeID = i;
            clickUpgrades.Add(upgrade);
        }
        for (int i = 0; i < data.passiveUpgradeLevel.Count; i++)
        {
            Upgrades upgrade2 = Instantiate(passiveUpgradePrefab, passiveUpgradesPanel.transform);
            upgrade2.UpgradeID = i;
            passiveUpgrades.Add(upgrade2);
        }
        clickUpgradesScroll.normalizedPosition = new Vector2(0,0);
        passiveUpgradesScroll.normalizedPosition = new Vector2(0,0);

        UpdateUpgradeUI("click");
        UpdateUpgradeUI("passive");
    }

    public void UpdateUpgradeUI(string type, int UpgradeID = -1)
    {
        switch (type)
        {
            case "click":
                if (UpgradeID == -1)
                {
                    for (int i = 0; i < clickUpgrades.Count; i++)
                        UpdateUI(clickUpgrades, data.clickUpgradeLevel, clickUpgradeNames, i);
                }
                else
                    UpdateUI(clickUpgrades, data.clickUpgradeLevel, clickUpgradeNames, UpgradeID);
                break;

            case "passive":
                if (UpgradeID == -1)
                {
                    for (int i = 0; i < passiveUpgrades.Count; i++)
                        UpdateUI(passiveUpgrades, data.passiveUpgradeLevel, passiveUpgradeNames, i);
                }
                else
                    UpdateUI(passiveUpgrades, data.passiveUpgradeLevel, passiveUpgradeNames, UpgradeID);
                break; 
        }
        
        void UpdateUI(List<Upgrades> upgrades, List<double> upgradeLevels, string[] upgradeNames, int ID)
        {
            upgrades[ID].LevelText.text = upgradeLevels[ID].ToString();
            upgrades[ID].CostText.text = $"Cost: {UpgradeCost(type, ID):F2} Gold";
            upgrades[ID].NameText.text = upgradeNames[ID];
        }
    }

    public double UpgradeCost(string type, int UpgradeID) 
    {
        switch (type)
        {
            case "click":
                return clickUpgradeBaseCost[UpgradeID] * Math.Pow(clickUpgradeMultiplier[UpgradeID], data.clickUpgradeLevel[UpgradeID]);
                break;
            case "passive":
                return passiveUpgradeBaseCost[UpgradeID] * Math.Pow(passiveUpgradeMultiplier[UpgradeID], data.passiveUpgradeLevel[UpgradeID]);
                break;
        }
        return 0;
    }

    public void BuyUpgrade(string type, int UpgradeID) 
    {
        switch (type)
        {
            case "click": Buy(data.clickUpgradeLevel);
                break;
            case "passive": Buy(data.passiveUpgradeLevel);
                break;
        }

        void Buy(List<double> upgradeLevels)
        {
            if (data.gold >= UpgradeCost(type, UpgradeID))
            {
                data.gold -= UpgradeCost(type, UpgradeID);
                upgradeLevels[UpgradeID] += 1;
            }
            UpdateUpgradeUI(type, UpgradeID);
        }
    }
}
