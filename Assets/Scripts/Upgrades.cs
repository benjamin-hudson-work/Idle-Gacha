using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour 
{
    public int UpgradeID;
    public Image UpgradeButton;
    public TMP_Text LevelText;
    public TMP_Text NameText;
    public TMP_Text CostText;
    public TMP_Text SubUpgradeName1;
    public TMP_Text SubUpgradeName2;
    public TMP_Text SubUpgradeName3;
    public TMP_Text SubUpgradeName4;
    public TMP_Text SubUpgradeCost1;
    public TMP_Text SubUpgradeCost2;
    public TMP_Text SubUpgradeCost3;
    public TMP_Text SubUpgradeCost4;

    public void Start()
    {
        //button.onClick.AddListener(() => { BuySubUpgrade(0); BuySubUpgrade(1); BuySubUpgrade(2); BuySubUpgrade(3); });
    }
    public void BuyClickUpgrade() => UpgradesManager.instance.BuyUpgrade("click", UpgradeID); 
    public void BuyPassiveUpgrade() => UpgradesManager.instance.BuyUpgrade("passive", UpgradeID);
    public void BuySubUpgrade(int buttonnumber) => UpgradesManager.instance.BuySubUpgrade(buttonnumber, UpgradeID);
}
