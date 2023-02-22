using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : Singleton<InGameUI>
{
    [SerializeField] private AbilityController _abilityController;
    [SerializeField] private List<AbilityButton> _abilityButtons;
    [SerializeField] private Sprite defaultSprite;

    private void Start()
    {
     Init();   
    }

    private void Init()
    {
        // Find all instances of the MyComponentType component and add them to the list
        AbilityButton[] abilityButtons = FindObjectsOfType<AbilityButton>();

        _abilityController = FindObjectOfType<AbilityController>();
        
        SortItems(abilityButtons, _abilityButtons);

        for (var i = 0; i < _abilityButtons.Count; i++)
        {
            // Check if the current index is out of range for _abilityController.Abilities
            if (i >= _abilityController.Abilities.Count)
            {
                // Do something with the non-null GameObject
                _abilityButtons[i].gameObject.SetActive(false);

                // Skip over the rest of the loop and continue to the next element in the array
                continue;
            }

            _abilityButtons[i].header = _abilityController.Abilities[i].AbilityName;
            _abilityButtons[i].content = _abilityController.Abilities[i].Description;

            // Check if the Icon sprite is null
            if (_abilityController.Abilities[i].Icon == null)
            {
                Debug.LogError("Please set an icon sprite to be shown for " + _abilityController.Abilities[i].AbilityName);
                
                // Set a default sprite for the button
                _abilityButtons[i]._sprite = defaultSprite;
            }
            else
            {
                _abilityButtons[i]._sprite = _abilityController.Abilities[i].Icon;
            }
        }
    }

    private void SortItems(AbilityButton[] objs, List<AbilityButton> objsList)
    {
        Array.Sort(objs, (a, b) => string.Compare(a.name, b.name));

        // Add the game objects to the list in alphabetical order
        foreach (AbilityButton obj in objs)
        {
            // Find the index where the object should be inserted based on its name
            int index = objsList.FindIndex(item => string.Compare(item.name, obj.name) > 0);

            // If the object should be inserted at the end of the list, add it with the Add method
            if (index == -1)
            {
                objsList.Add(obj);
            }
            // Otherwise, insert the object at the appropriate index
            else
            {
                objsList.Insert(index, obj);
            }
        }
    }
}
