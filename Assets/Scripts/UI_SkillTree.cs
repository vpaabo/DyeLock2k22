using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillTree : MonoBehaviour
{
    public List<SkillButton> SkillButtons;
    private void Awake()
    {
        /*foreach (var skillButton in SkillButtons)
        {
            skillButton.button.onClick.AddListener(ButtonClicked);
        }*/
    }

    public void ButtonClicked()
    {
        print(this.name + "clicked");
    }
}
