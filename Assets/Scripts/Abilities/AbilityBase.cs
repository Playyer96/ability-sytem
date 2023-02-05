using UnityEngine;
using UnityEngine.InputSystem;

public abstract class AbilityBase : MonoBehaviour
{
    [SerializeField] private string _abilityName;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isEnable;

    public string AbilityName { get => _abilityName; set => _abilityName = value; }
    public string Description { get => _description; set => _description = value; }
    public Sprite Icon { get => _icon; set => _icon = value; }
    public bool IsEnable { get => _isEnable; set => _isEnable = value; }

    public abstract void UseAbility();

    /// <summary>
    /// Here you need to write your ability code
    /// </summary>
    public abstract void Ability();
}
