using UnityEngine;

public class TooltipSystem : Singleton<TooltipSystem>
{
    [SerializeField] private Tooltip tooltip;

    private void Start()
    {
        if(!HasInstance())
            Init();

        if (!tooltip)
        {
            tooltip = FindObjectOfType<Tooltip>();
            Show(false);
        }
        else
            Show(false);
        
    }

    public static void Show(bool enable, string name = "", string description = "")
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
        {
            return;
        }
        
        Instance.tooltip.SetText(name, description);
        Show(enable);
    }

    public static void Show(bool enable)
    {
        Instance.tooltip.gameObject.SetActive(enable);
    }
}
