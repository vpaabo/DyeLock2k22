using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    private Button button;
    public SkillButton prevUpgrade;
    public PlayerSkills.SkillType Skill;

    public Color buttonColor;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(AddSkill);
        button.GetComponentInChildren<TextMeshProUGUI>().text = Skill.ToString();
        button.GetComponentInChildren<TextMeshProUGUI>().fontSize = 15;
    }

    private void Start()
    {
        if (prevUpgrade != null)
        {
            button.interactable = false;
            prevUpgrade.button.onClick.AddListener(UnlockButton);
        }
    }

    public void UnlockButton()
    {
        button.interactable = true;
    }
    public void AddSkill()
    {
        print("Button clicked: " + Skill.ToString());
        Events.SetUpgrade(Skill, true);
        button.interactable = false;
    }
}
