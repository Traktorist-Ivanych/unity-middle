using UnityEditor;
using UnityEngine;

public class ConfigurationsPathes : EditorWindow
{
    private string[] configList;

    [MenuItem("Window/Configurations Pathes")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ConfigurationsPathes));
    }

    private void OnGUI()
    {
        configList = AssetDatabase.FindAssets("t:SOConfiguration");
        GUILayout.Label("Configurations Pathes List", EditorStyles.boldLabel);
        GUILayout.Space(10);
        foreach (string config in configList)
        {
            GUILayout.Label(AssetDatabase.GUIDToAssetPath(config), EditorStyles.label);
        }
    }
}
