using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(EnemiesSpawnerComponent))]
public class EnemiesSpawnerComponentEditor : Editor
{
   // SerializedProperty waveScripts;
    

    private void OnEnable()
    {
        //waveScripts = serializedObject.FindProperty("waveScripts");
        
    }
    public override void OnInspectorGUI()
    {
        //serializedObject.Update();
      
        //EditorGUILayout.PropertyField(waveScripts, new GUIContent("Wave Scripts "), GUILayout.Height(waveScripts.arraySize*20+75));
        
        
        base.OnInspectorGUI();
    }

   
}
