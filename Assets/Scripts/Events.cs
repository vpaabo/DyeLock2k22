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

    
}
