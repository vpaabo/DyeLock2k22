using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    private Button button;
    public PlayerSkills.SkillType Skill;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(AddSkill);
        button.GetComponentInChildren<TextMeshProUGUI>().text = Skill.ToString();
        button.GetComponentInChildren<TextMeshProUGUI>().fontSize = 15;
    }

    public void AddSkill()
    {
        print("Button clicked: " + Skill.ToString());
        Events.SetUpgrade(Skill, true);
    }
}
