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

    public void BuyClickUpgrade() => UpgradesManager.instance.BuyUpgrade("click", UpgradeID); 
    public void BuyPassiveUpgrade() => UpgradesManager.instance.BuyUpgrade("passive", UpgradeID); 
    
}