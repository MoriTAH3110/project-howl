using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(SceneNameDropDownAttribute))]
public class SceneNameDropDownDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.String) {
            string [] sceneNames = SceneUtilityHelper.GetSceneNamesInBuildSettings();

            int selectedIndex = Mathf.Max(0, System.Array.IndexOf(sceneNames, property.stringValue));

            EditorGUI.BeginChangeCheck();
            selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, sceneNames);

            if (EditorGUI.EndChangeCheck()) {
                property.stringValue = sceneNames[selectedIndex];
            }

        }
        else 
        {
            EditorGUI.LabelField(position, label, "Use with string values only");
        }
    }
}
