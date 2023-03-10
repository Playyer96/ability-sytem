public class InputMasterHelper
{
    public static string[] GetInputActionArray()
    {
        InputMaster inputMaster = new InputMaster();

        var actionMap = inputMaster.AbilitySystem.Get();

        string[] actionNames = new string[actionMap.actions.Count];

        for (int i = 0; i < actionNames.Length; i++)
        {
            actionNames[i] = actionMap.actions[i].name;
        }

        return actionNames;
    }
}
