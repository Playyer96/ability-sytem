using UnityEngine;

public class TooltipSystem : Singleton<TooltipSystem>
{
    public static TooltipSystem tooltipSystem;

    [SerializeField] private Tooltip tooltip;

    private void Start()
    {
        if (!tooltip)
            tooltip = FindObjectOfType<Tooltip>();
        
        Show(false);
    }

    public static void Show(bool enable, string content, string header = "")
    {
        if (string.IsNullOrEmpty(header) || string.IsNullOrEmpty(content))
        {
            return;
        }
        
        tooltipSystem.tooltip.SetText(content, header);
        Show(enable);
    }

    public static void Show(bool enable)
    {
        tooltipSystem.tooltip.gameObject.SetActive(enable);
    }
}
