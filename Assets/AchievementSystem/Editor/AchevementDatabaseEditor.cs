using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

[CustomEditor(typeof(AchevementDatabase))]
public class AchevementDatabaseEditor : Editor
{
    private AchevementDatabase database;

    private void OnEnable()
    {
       database = target as AchevementDatabase;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Generate Enum",GUILayout.Height(30)))
        {
            GenerateEnum();
        }
    }

    public void GenerateEnum()
    {
        string filePath = Path.Combine(Application.dataPath, "Achievement.cs");
        string code = "public enum Achevements{";
        foreach(Achevement achievement in database.achevements)
        {
            code += achievement.id + ",";
        }
        code += "}";
        File.WriteAllText(filePath, code);
        AssetDatabase.ImportAsset("Assets/Achevements.cs");
    }
}