using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Data
{
    public double gold;
    public List<double> clickUpgradeLevel; 
    public List<double> passiveUpgradeLevel; 
    public double highestLevel;
    public double currentLevel;

    public Data()
    {
        gold = 0;

        clickUpgradeLevel = Methods.CreateList<double>(3);
        passiveUpgradeLevel = Methods.CreateList<double>(3);

        highestLevel = 9;
        currentLevel = 0;
    }
}
