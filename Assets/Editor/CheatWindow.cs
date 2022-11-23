using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static PlayerSkills;

public class CheatWindow : EditorWindow
{
    private bool groupEnabled;
    private List<SkillType> allSkills;
    private List<bool> allSkillsBools;

    [MenuItem("Window/Cheat Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CheatWindow));
    }

    // TODO: How to call event on button toggle?

    private void Awake()
    {
        allSkills = new List<SkillType>();
        allSkillsBools = new List<bool>();

        foreach (PlayerSkills.SkillType skillType in Enum.GetValues(typeof(PlayerSkills.SkillType)))
        {
            allSkills.Add(skillType);
            allSkillsBools.Add(false); // TODO: Make it dynamically get values somehow
        }
        Debug.Log(allSkills.Count);
        Debug.Log(allSkillsBools.Count);
    }

    private void OnGUI()
    {
        groupEnabled = EditorGUILayout.BeginToggleGroup("Enable cheats", groupEnabled);
        for (int i = 0; i < allSkills.Count; i++)
        {
            allSkillsBools[i] = EditorGUILayout.Toggle(allSkills[i].ToString(), allSkillsBools[i]);
        }
        EditorGUILayout.EndToggleGroup();
    }

    private void Update()
    {
        if (groupEnabled)
        {
            for (int i = 0; i < allSkills.Count;i++)
            {
                Events.SetUpgrade(allSkills[i], allSkillsBools[i]);
            }
        }
    }
}
