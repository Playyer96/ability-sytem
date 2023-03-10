using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string _name;
    public string _description;

    private void OnEnable()
    {
        TooltipSystem.Show(true, _name, _description);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (TooltipSystem.Instance)
            TooltipSystem.Show(true, _name, _description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Show(false);
    }
}
