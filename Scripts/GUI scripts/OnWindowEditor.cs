using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class OnWindowEditor : EditorWindow {

    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    [MenuItem("Window/TestEditor")]
    public static void WindowAdd()
    {
        EditorWindow.GetWindow(typeof(OnWindowEditor));
    }

    private void OnGUI()
    {
        //example settings from Unity Doc
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();
    }
}
