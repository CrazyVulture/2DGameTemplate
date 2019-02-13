using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameController))]
public class GameEditor : Editor
{
    //Game Type
    private SerializedProperty gameType;
    //Collect game
    private SerializedProperty charaController;
    //Catcher game
    private SerializedProperty ballController;
    private SerializedProperty hatController;
    
    private void OnEnable()
    {
        //Game Type
        gameType = serializedObject.FindProperty("gameType");
        //Collect game
        charaController = serializedObject.FindProperty("charaController");
        //Catcher game
        ballController = serializedObject.FindProperty("ballController");
        hatController = serializedObject.FindProperty("hatController");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();
        
        EditorGUILayout.PropertyField(gameType, new GUIContent("GameType"));

        switch(gameType.enumValueIndex)
        {
            case 0:
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(charaController, new GUIContent("CharaController"));
                EditorGUI.indentLevel--;
                break;
            case 1:
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(ballController, new GUIContent("BallController"));
                EditorGUILayout.PropertyField(hatController, new GUIContent("HatController"));
                EditorGUI.indentLevel--;
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
