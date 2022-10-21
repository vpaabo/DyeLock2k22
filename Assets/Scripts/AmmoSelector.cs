using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public class AmmoSelector : MonoBehaviour
{
    /*public Image redFlame;
    public Image blueFlame;
    public Image greenFlame;*/

    public List<Image> spells;
    private int SelectedSpell = 0;

    private void Awake()
    {
        Events.OnSpellSelected += OnSpellSelected;
    }

    private void OnDestroy()
    {
        Events.OnSpellSelected -= OnSpellSelected;
    }

    private void Start()
    {
        for (int i = 0; i < spells.Count; i++)
        {
            if (i == SelectedSpell) continue;
            Color c = spells[i].color;
            spells[i].color = ChangeOpacity(spells[i].color, 0.3f);
        }
    }
    private void Update()
    {
        
    }

    private Color ChangeOpacity(Color c, float alpha)
    {
        return new Color(c.r, c.g, c.b, alpha);
    }

    void OnSpellSelected(int n)
    {
        print("spell changed to:" + n);
        
        spells[SelectedSpell].color = ChangeOpacity(spells[SelectedSpell].color, 0.3f);
        spells[n].color = ChangeOpacity(spells[n].color, 1);
        SelectedSpell = n;
    }
}
