using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    // Select spell
    public static event Action<int> OnSpellSelected;
    public static void SelectSpell(int spell) => OnSpellSelected?.Invoke(spell);

    
}
