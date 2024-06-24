using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class DownDownController : MonoBehaviour
{
 private Dropdown ach_dropdown;
 private Dropdown Dropdown
    {
        get {
            if (ach_dropdown == null)
            {
                ach_dropdown=GetComponent<Dropdown>();
            }
            return ach_dropdown;
        }
    }

    public Action<Achevements>onValueChanged;
    private void Start()
    {
      UpdateOptions();
      Dropdown.onValueChanged.AddListener(HandleDropdownValueChanged);
     
    }
    [ContextMenu("UpdateOptions()")]
    public void UpdateOptions()
    {
        Dropdown.options.Clear();
       var values= System.Enum.GetValues(typeof(Achevements));
        foreach(Achevements achievement in values)
        {
            Dropdown.options.Add(new Dropdown.OptionData(achievement.ToString()));
        }
        Dropdown.RefreshShownValue();
    }
    private void HandleDropdownValueChanged(int value)
    {
        if (onValueChanged != null) { onValueChanged((Achevements)value);}
    }
}
