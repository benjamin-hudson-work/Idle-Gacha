using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Navigation : MonoBehaviour
{
    public GameObject ClickUpgradesSelected;
    public GameObject PassiveUpgradesSelected;

    public TMP_Text ClickUpgradesTitleText;
    public TMP_Text PassiveUpgradesTitleText;

    public GameObject HomeScreen;
    public GameObject SettingsScreen;

    public void SwitchUpgrades(string location)
    {
        UpgradesManager.instance.clickUpgradesScroll.gameObject.SetActive(false);
        UpgradesManager.instance.passiveUpgradesScroll.gameObject.SetActive(false);
        
        ClickUpgradesSelected.SetActive(false);
        PassiveUpgradesSelected.SetActive(false);

        ClickUpgradesTitleText.color = Color.white;
        PassiveUpgradesTitleText.color = Color.white;

        switch (location)
        {
            case "Click":
                UpgradesManager.instance.clickUpgradesScroll.gameObject.SetActive(true);
                ClickUpgradesSelected.SetActive(true);
                ClickUpgradesTitleText.color = Color.grey;
                break;
            case "Passive": 
                UpgradesManager.instance.passiveUpgradesScroll.gameObject.SetActive(true);
                PassiveUpgradesSelected.SetActive(true);
                PassiveUpgradesTitleText.color = Color.grey;
                break;
        }
    }

    public void Navigate(string location)
    {
        HomeScreen.SetActive(false);
        SettingsScreen.SetActive(false);

        switch (location)
        {
            case "Home":
                HomeScreen.SetActive(true);
                break;
            case "Settings":
                SettingsScreen.SetActive(true);
                break;
        }
    }
}
