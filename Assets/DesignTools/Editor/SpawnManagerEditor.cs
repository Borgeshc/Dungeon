using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnManager)), CanEditMultipleObjects]
public class SpawnManagerEditor : Editor
{
    public SerializedProperty

        state_Prop,
        enemiesPerWave_Prop,
        increaseEnemiesInWaveBy_Prop,
        totalWaves_Prop,
        totalEnemies_Prop,
        surviveFor_Prop,
        nextWaveAt_Prop,
        enemiesPerEachWave_Prop;


    void OnEnable()
    {
        // Setup the SerializedProperties
        state_Prop = serializedObject.FindProperty("state");

        //Wave Variables
        enemiesPerWave_Prop = serializedObject.FindProperty("enemiesPerWave");
        increaseEnemiesInWaveBy_Prop = serializedObject.FindProperty("increaseEnemiesInWaveBy");
        totalWaves_Prop = serializedObject.FindProperty("totalWaves");

        //One Time Spawn Variables
        totalEnemies_Prop = serializedObject.FindProperty("totalEnemies");

        //Survival Variables
        surviveFor_Prop = serializedObject.FindProperty("surviveFor");
        nextWaveAt_Prop = serializedObject.FindProperty("nextWaveAt");
        enemiesPerEachWave_Prop = serializedObject.FindProperty("enemiesPerEachWave");

    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();

        EditorGUILayout.PropertyField(state_Prop, new GUIContent("Object"));
        SpawnManager.Status st = (SpawnManager.Status)state_Prop.enumValueIndex;
        EditorGUIUtility.LookLikeInspector();

        switch (st)
        {
            case SpawnManager.Status.None:
                break;

            case SpawnManager.Status.Waves:
                EditorGUILayout.PropertyField(enemiesPerWave_Prop, new GUIContent("How many enemies per wave"));
                EditorGUILayout.PropertyField(increaseEnemiesInWaveBy_Prop, new GUIContent("Increase amout of enemies per wave"));
                EditorGUILayout.PropertyField(totalWaves_Prop, new GUIContent("Total number of waves"));
                break;

            case SpawnManager.Status.OneTimeSpawn:
                EditorGUILayout.PropertyField(totalEnemies_Prop, new GUIContent("How many enemies to spawn"));
                break;

            case SpawnManager.Status.SurviveForTime:
                EditorGUILayout.PropertyField(surviveFor_Prop, new GUIContent("Must survive for how long in seconds"));
                EditorGUILayout.PropertyField(nextWaveAt_Prop, new GUIContent("Next time you spawn enemies in seconds"));
                EditorGUILayout.PropertyField(enemiesPerEachWave_Prop, new GUIContent("How many enemies do you spawn at a time"));
                break;
        }
        serializedObject.ApplyModifiedProperties();
        EditorGUIUtility.LookLikeControls();
    }
}
