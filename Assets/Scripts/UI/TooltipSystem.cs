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

    public static void Show(bool enable, string header = "", string content = "")
    {
        if (string.IsNullOrEmpty(header) || string.IsNullOrEmpty(content))
        {
            return;
        }
        
        Instance.tooltip.SetText(content, header);
        Show(enable);
    }

    public static void Show(bool enable)
    {
        Instance.tooltip.gameObject.SetActive(enable);
    }
}
