using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string name;
    public string description;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Show(true, name, description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Show(false);
    }
}
