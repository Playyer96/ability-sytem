using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillsUI : MonoBehaviour
{
 [SerializeField] private AbilityController _abilityController;

 [Header("Skill Attributes")] [SerializeField]
 private TextMeshProUGUI characterName;

 [SerializeField] private List<SkillsAttributes> _skillsAttributesList;
 [SerializeField] private Sprite defaultSprite;


 private void Start()
 {
  if (!_abilityController)
   _abilityController = FindObjectOfType<AbilityController>();

  characterName.text = _abilityController.gameObject.name;
  
  for (var i = 0; i < _skillsAttributesList.Count; i++)
  {
   // Check if the current index is out of range for _abilityController.Abilities
   if (_skillsAttributesList.Count <= _abilityController.Abilities.Count || _abilityController.Abilities is IActivable)
   {
    // Do something with the non-null GameObject
    _skillsAttributesList[i].panel.SetActive(true);

    // Skip over the rest of the loop and continue to the next element in the array
   }
   else
   {
    _skillsAttributesList[i].panel.SetActive(false);
   }
   
   _skillsAttributesList[i].name.text = _abilityController.Abilities[i].AbilityName;
   _skillsAttributesList[i].description.text = _abilityController.Abilities[i].Description;

   // Check if the Icon sprite is null
   if (_abilityController.Abilities[i].Icon == null)
   {
    Debug.LogError("Please set an icon sprite to be shown for " + _abilityController.Abilities[i].AbilityName);

    // Set a default sprite for the button
    _skillsAttributesList[i].icon.sprite = defaultSprite;
   }
   else
   {
    _skillsAttributesList[i].icon.sprite = _abilityController.Abilities[i].Icon;
   }
  }
 }
}

[System.Serializable]
public class SkillsAttributes
{
 public GameObject panel;
 public TextMeshProUGUI name;
 public TextMeshProUGUI description;
 public Image icon;
}