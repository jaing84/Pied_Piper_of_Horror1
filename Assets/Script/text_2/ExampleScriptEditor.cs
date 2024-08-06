using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(SpeechSystem))]
public class ExampleScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SpeechSystem script = (SpeechSystem)target;

        script.A位 = (Image)EditorGUILayout.ObjectField("A位", script.A位, typeof(Image), true);

        script.展開BC = EditorGUILayout.Foldout(script.展開BC, "展開 BC");
        if (script.展開BC)
        {
            EditorGUI.indentLevel++;
            script.B位 = (Image)EditorGUILayout.ObjectField("B位", script.B位, typeof(Image), true);
            script.C位 = (Image)EditorGUILayout.ObjectField("C位", script.C位, typeof(Image), true);
            EditorGUI.indentLevel--;
        }

        // Ensure any changes to the script are saved
        if (GUI.changed)
        {
            EditorUtility.SetDirty(script);
        }
    }
}
