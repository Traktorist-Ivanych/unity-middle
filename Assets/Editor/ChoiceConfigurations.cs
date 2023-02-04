using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(DIInstaller))]
public class ChoiceConfigurations : Editor
{
    private SerializedProperty currentSOConfig;
    private SOConfiguration[] sOConfigs;

    private void OnEnable()
    {
        currentSOConfig = serializedObject.FindProperty("sOConfig");
        sOConfigs = Resources.FindObjectsOfTypeAll<SOConfiguration>();
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Space(6);
        GUILayout.Label("Configurations List", EditorStyles.boldLabel);
        GUILayout.Space(10);

        foreach (SOConfiguration sOConfig in sOConfigs)
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.ObjectField(sOConfig, typeof(SOConfiguration), true);
            EditorGUILayout.LabelField("Max HP " + sOConfig.MaxPlayerHP + " | PlayerSpeed " + sOConfig.PlayerMoveSpeed);
            if (GUILayout.Button("Set"))
            {
                currentSOConfig.objectReferenceValue = sOConfig;
            }
            EditorGUILayout.EndVertical();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
