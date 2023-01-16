using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NecessaryObjectsImporterScript))]
public class NecessaryObjectsImporterScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        NecessaryObjectsImporterScript necessaryObjectsImporterScript = (NecessaryObjectsImporterScript)target;
       
        base.OnInspectorGUI();
       
        if (GUILayout.Button("Spawn"))
        {
            necessaryObjectsImporterScript.OnClick();            
        }

        if (GUILayout.Button("Remove"))
        {
            necessaryObjectsImporterScript.Remove();
        }

       
    }
}
