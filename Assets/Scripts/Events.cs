using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Events : MonoBehaviour
{
    // pause game
    public static event Action OnGamePaused;
    public static void PauseGame() => OnGamePaused?.Invoke();

    // unpause game
    public static event Action OnGameUnPaused;
    public static void UnPauseGame() => OnGameUnPaused?.Invoke();


    // Select spell with scroll wheel (// TODO with numbers)
    public static event Action<int> OnSpellSelected;
    public static void SelectSpell(int spell) => OnSpellSelected?.Invoke(spell);

    // Apply movement force to player (used by explosions etc)
    public static event Action<Vector3, float> OnAddForceToPlayer;
    public static void AddForceToPlayer(Vector3 direction, float amount) => OnAddForceToPlayer?.Invoke(direction, amount);

    // Set upgrade availability for player
    public static event Action<PlayerSkills.SkillType, bool> OnSetUpgrade;
    public static void SetUpgrade(PlayerSkills.SkillType skill, bool value) => OnSetUpgrade?.Invoke(skill, value);

    // Events for affecting player resources
    public static event Action<int, int, int> OnAddResources;
    public static void AddResources(int red, int green, int blue) => OnAddResources?.Invoke(red, green, blue);
    public static event Action<int, int, int> OnUseResources;
    public static void UseResources(int red, int green, int blue) => OnUseResources?.Invoke(red, green, blue);
    public static event Action<int, int, int> OnSetResources;
    public static void SetResources(int red, int green, int blue) => OnSetResources?.Invoke(red, green, blue);
}
