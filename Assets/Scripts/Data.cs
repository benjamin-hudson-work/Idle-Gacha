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
    public double monstersLeft;

    public bool NextLevelOnClear;
    public bool AutoSave;

    public Data()
    {
        gold = 0;

        clickUpgradeLevel = Methods.CreateList<double>(3);
        passiveUpgradeLevel = Methods.CreateList<double>(3);

        highestLevel = 1;
        currentLevel = 1;
        NextLevelOnClear = true;
        AutoSave = false;
        monstersLeft = 10;
    }
}
