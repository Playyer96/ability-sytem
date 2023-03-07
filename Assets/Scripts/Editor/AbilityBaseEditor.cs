using UnityEditor;

[CustomEditor(typeof(AbilityBase), true), CanEditMultipleObjects]
public class AbilityBaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        serializedObject.Update();

        SerializedProperty serializedProperty = serializedObject.FindProperty("_abilityAction");

        if (serializedProperty != null)
        {
            serializedProperty.intValue =
                EditorGUILayout.Popup("Ability Action", serializedProperty.intValue, InputMasterHelper.GetInputActionArray());
        }

        serializedObject.ApplyModifiedProperties();
    }
}
