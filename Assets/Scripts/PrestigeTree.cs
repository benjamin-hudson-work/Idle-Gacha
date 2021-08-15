using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrestigeTree : MonoBehaviour
{
    public static PrestigeTree skillTree;
    private void Awake() => skillTree = this;
 
    public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;

    public List<Skill> SkillList;
    public GameObject SkillHolder; 
    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;
    public void StartPrestigeTree()
    {
        SkillCaps = new[] {1, 1, 1, 1, 1, 1};
        SkillNames = new[] {"Upgrade 1", "Upgrade 2", "Upgrade 3", "Upgrade 4", "Booster 5", "Booster 6"};
        SkillDescriptions = new[]
        {
            "Does thing 1",
            "Does thing 2",
            "Improved rates or something",
            "Quality of life",
            "Does strong thing",
            "Does stronger thing!"
        };

        foreach (var skill in SkillHolder.GetComponentsInChildren<Skill>()) SkillList.Add(skill);
        
        for (var i = 0; i < SkillList.Count; i++) SkillList[i].id = i;

        SkillList[0].ConnectedSkills = new[] {1};
        SkillList[1].ConnectedSkills = new[] {2, 3, 5};
        SkillList[3].ConnectedSkills = new[] {4};

        UpdateAllSkillUI();
    }
    public void UpdateAllSkillUI()
    {
        foreach (var skill in SkillList) skill.UpdateUI();
    }
}
