using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputMasterHelper
{
    public static string[] GetInputActionArray()
    {
        InputMaster inputMaster = new InputMaster();

        string[] actionNames = new string[inputMaster.AbilitySystem.Get().actions.Count];

        for (int i = 0; i < actionNames.Length; i++)
        {
            actionNames[i] = inputMaster.AbilitySystem.Get().actions[i].name;
        }

        return actionNames;
    }
}
