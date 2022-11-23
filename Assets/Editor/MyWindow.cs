using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Drawing.Printing;
using System;
using Unity.VisualScripting;

public class MyWindow : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    
 
    // Add menu named "My Window" to the Window menu
    [MenuItem("Window/My Window")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        MyWindow window = (MyWindow)EditorWindow.GetWindow(typeof(MyWindow));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();


        GUILayout.Label("button to activate/deactivate point");
        if (GUILayout.Button("test button"))
        {
            MyFunc();
        }
    }

    GameObject point;
    void MyFunc()
    {
        Debug.Log("button pressed");

        if(point == null) point = GameObject.Find("point");
        point.SetActive(!point.activeSelf);
    }
}