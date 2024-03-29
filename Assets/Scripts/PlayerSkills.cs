using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills
{
    // Kui paned uue skilli siis pane siia sellele nimi ka
    public enum SkillType
    {
        /*
         * Naming conventions
         * 
         *  - NAME FORMAT: <colour>_<upgrade name>_<upgrade tier>
         *      <colour> - colour indicator
         *          R - red
         *          G - green
         *          B - blue
         *      <upgrade name> - upgrade name/keyword
         *      <upgrade tier> - indicate upgrade tier (OPTIONAL)
         *      
         *  - CODE FORMAT: XYYZ (4-digit number)
         *      X - colour indicator
         *          1 - red
         *          2 - green
         *          3 - blue
         *      YY - nr of upgrade
         *          range of 01 - 99
         *      Z - tier of upgrade
         *          0 - upgrade has no tiers
         *          1-9 - upgrade has tiers
         */
        R_BURST_1 = 1011,
        R_BURST_2 = 1012,

        G_BOOST = 2010,

        B_SPEED_1 = 3011,
        B_SPEED_2 = 3012
    }

    // Kui paned uue skilli siis pane siia sellele nimi ka
    public static Dictionary<PlayerSkills.SkillType, string> SkillNames = new Dictionary<SkillType, string>()
    {
        { SkillType.R_BURST_1, "punane 1"},
        { SkillType.R_BURST_2, "punane 2"},
        { SkillType.G_BOOST, "roheline 1"},
        { SkillType.B_SPEED_1, "sinine 1"},
        { SkillType.B_SPEED_2, "sinine 2"},

    };
    private List<SkillType> unlockedSkills;

    public PlayerSkills()
    {
        unlockedSkills = new List<SkillType>();
    }

    public void UnlockSkill(SkillType skill)
    {
        if (unlockedSkills.Contains(skill)) return;
        unlockedSkills.Add(skill);
    }

    public bool isSkillUnlocked(SkillType skill)
    {
        return unlockedSkills.Contains(skill);
    }

    public static string GetSkillName(SkillType skill)
    {
        return SkillNames.GetValueOrDefault(skill, "NO NAME YET");
    }
}
