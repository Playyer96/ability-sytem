using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string _name;
    public string _description;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Show(true, _name, _description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Show(false);
    }
}
