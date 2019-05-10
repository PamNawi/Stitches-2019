using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SmartObject))]
public class SmartObjectEditor : BehaviorExecutorEditor
{
    public override void OnInspectorGUI () {
        base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("changedNeed"), true);
        serializedObject.ApplyModifiedProperties();
	}
}
