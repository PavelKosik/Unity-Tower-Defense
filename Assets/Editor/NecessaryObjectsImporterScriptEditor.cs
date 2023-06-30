using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//spawns all the neccesary managers in the level
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
