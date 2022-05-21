using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuitChanger : MonoBehaviour
{
   [SerializeField] private Toggle _toggle;

   public static Action<SuitInfo> onSuitChanged;
   
   private void Start()
   {
      _toggle.onValueChanged.AddListener(OnToggleChanged);
      if (GetComponent<SuitInfo>().IsApplied)
      {
         _toggle.isOn = true;
         gameObject.SetActive(true);
      }
      else
      {
         gameObject.SetActive(false);
         _toggle.isOn = false;
         return;
      }
      onSuitChanged?.Invoke(GetComponent<SuitInfo>());
   }

   private void OnToggleChanged(bool active)
   {
      if (active)
      {
         onSuitChanged?.Invoke(GetComponent<SuitInfo>());
      }
      gameObject.SetActive(active);
   }
}
