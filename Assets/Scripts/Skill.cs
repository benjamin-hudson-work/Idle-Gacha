using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static PrestigeTree;
public class Skill : MonoBehaviour
{
    public int id;
    public TMP_Text TitleText;
    public TMP_Text DescriptionText;
    public int[] ConnectedSkills;

    public void UpdateUI()
    {
        TitleText.text = $"{skillTree.SkillNames[id]}";
        DescriptionText.text = $"{skillTree.SkillDescriptions[id]}\nCost: {skillTree.SkillPoint}/1 Point";

        GetComponent<Image>().color = Controller.instance.data.SkillLevels[id] >= skillTree.SkillCaps[id] ? Color.yellow :
            skillTree.SkillPoint > 0 ? Color.green : Color.white; //yellow if max, green if afford, white if neither.
        
        foreach (var connectedSkill in ConnectedSkills)
        {
            skillTree.SkillList[connectedSkill].gameObject.SetActive(Controller.instance.data.SkillLevels[id] > 0);
            skillTree.ConnectorList[connectedSkill].SetActive(Controller.instance.data.SkillLevels[id] > 0);
        }
    }
    public void Buy()
    {
        if (skillTree.SkillPoint < 1 || Controller.instance.data.SkillLevels[id] >= skillTree.SkillCaps[id]) return;
        skillTree.SkillPoint -= 1;
        Controller.instance.data.SkillLevels[id]++;
        skillTree.UpdateAllSkillUI();
    }
}
