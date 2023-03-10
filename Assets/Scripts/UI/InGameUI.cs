using System.Collections.Generic;
using UnityEngine;

public class InGameUI : Singleton<InGameUI>
{
    [SerializeField] private AbilityController _abilityController;
    [SerializeField] private AbilityButton _abilityButtonPrefab;
    [SerializeField] private Transform _abilityButtonParent;
    [SerializeField] private Sprite _defaultSprite;

    private List<AbilityButton> _abilityButtons = new List<AbilityButton>();
    
    private void Start()
    {
        _abilityController = FindObjectOfType<AbilityController>();

        AbilityButton[] abilityButtons = FindObjectsOfType<AbilityButton>();

        if (abilityButtons.Length > 0)
        {
            _abilityButtons = new List<AbilityButton>(abilityButtons);

            // Remove any existing ability buttons
            foreach (AbilityButton button in _abilityButtons)
            {
                Destroy(button.gameObject);
            }
        }

        _abilityButtons.Clear();

        // Create a button for each ability in the Abilities list
        foreach (AbilityBase ability in _abilityController.Abilities)
        {
            if (ability is IActivable)
            {
                // Create a new ability button from the prefab and add it to the parent transform
                AbilityButton button = Instantiate(_abilityButtonPrefab, _abilityButtonParent);
                _abilityButtons.Add(button);

                // Set the button header, content, and icon
                button._name = ability.AbilityName;
                button._description = ability.Description;
                // button.SetIcon(ability.Icon ?? _defaultSprite);
                button.SetIcon(ability.Icon);
            }
        }
    }
}