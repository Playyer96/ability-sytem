using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : TooltipTrigger
{
    private Button _button;
    private Sprite _sprite;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void SetIcon(Sprite sprite)
    {
        _sprite = sprite;
        _button.image.sprite = _sprite ?? _button.image.sprite;
    }
}
