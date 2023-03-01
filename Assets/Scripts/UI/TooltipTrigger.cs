using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    public string description;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Show(true, header, description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Show(false);
    }
}
