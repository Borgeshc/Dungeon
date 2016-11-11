using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Triggers)), CanEditMultipleObjects]
public class TriggersEditor : Editor
{
    public SerializedProperty

        type_Prop,
        effect_Prop,
        //Animation properties
        animator_Prop,
        animationClip_Prop,

        //LoadScene Properties
        nextLevel_Prop;

    void OnEnable()
    {
        // Setup the SerializedProperties
        type_Prop = serializedObject.FindProperty("type");
        effect_Prop = serializedObject.FindProperty("effect");
        //List all the variables
        //PlayAnimation Variables
        animator_Prop = serializedObject.FindProperty("animatorController");
        animationClip_Prop = serializedObject.FindProperty("animationClips");

        //LoadScene Variables
        nextLevel_Prop = serializedObject.FindProperty("nextLevel");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();

        EditorGUILayout.PropertyField(type_Prop, new GUIContent("Trigger Type"));

        Triggers.TriggerType type = (Triggers.TriggerType)type_Prop.enumValueIndex;

        Triggers.TriggeredEffect effect = (Triggers.TriggeredEffect)effect_Prop.enumValueIndex;
        EditorGUIUtility.LookLikeInspector();

        switch (type)
        {
            case Triggers.TriggerType.None:
                break;

            case Triggers.TriggerType.OnTriggerEnter:

                EditorGUILayout.PropertyField(effect_Prop, new GUIContent("Effect Type"));
                switch (effect)
                {
                    case Triggers.TriggeredEffect.None:
                        break;
                    case Triggers.TriggeredEffect.PlayAnimation:
                        PlayAnimation();
                        break;
                    case Triggers.TriggeredEffect.Collectables:
                        break;
                    case Triggers.TriggeredEffect.TakeDamage:
                        break;
                    case Triggers.TriggeredEffect.Died:
                        break;
                    case Triggers.TriggeredEffect.LoadNextLevel:
                        LoadNextLevel();
                        break;
                }
                //EditorGUILayout.Slider(sunMinSize_Prop, 0, 1000, new GUIContent("Sun's Min Size"));
                break;

            case Triggers.TriggerType.OnTriggerExit:

                EditorGUILayout.PropertyField(effect_Prop, new GUIContent("effect"));
                switch (effect)
                {
                    case Triggers.TriggeredEffect.None:
                        break;
                    case Triggers.TriggeredEffect.PlayAnimation:
                        PlayAnimation();
                        break;
                    case Triggers.TriggeredEffect.Collectables:
                        break;
                    case Triggers.TriggeredEffect.TakeDamage:
                        break;
                    case Triggers.TriggeredEffect.Died:
                        break;
                    case Triggers.TriggeredEffect.LoadNextLevel:
                        LoadNextLevel();
                        break;
                   
                }
                //EditorGUILayout.Slider(planetSpeed_Prop, 0, 1000, new GUIContent("Planet's Speed"));
                break;

            case Triggers.TriggerType.OnTriggerStay:

                EditorGUILayout.PropertyField(effect_Prop, new GUIContent("effect"));
                switch (effect)
                {
                    case Triggers.TriggeredEffect.None:
                        break;
                    case Triggers.TriggeredEffect.PlayAnimation:
                        PlayAnimation();
                        break;
                    case Triggers.TriggeredEffect.Collectables:
                        break;
                    case Triggers.TriggeredEffect.TakeDamage:
                        break;
                    case Triggers.TriggeredEffect.Died:
                        break;
                    case Triggers.TriggeredEffect.LoadNextLevel:
                        LoadNextLevel();
                        break;
               
                }
                //EditorGUILayout.Slider(moonSpeed_Prop, 0, 1000, new GUIContent("Moon's Speed"));
                break;

        }
        serializedObject.ApplyModifiedProperties();
        EditorGUIUtility.LookLikeControls();
    }

    void PlayAnimation()
    {
        EditorGUILayout.PropertyField(animator_Prop, new GUIContent("Animator Controller"));
        EditorGUILayout.PropertyField(animationClip_Prop, new GUIContent("Animation Clips"), true);
    }

    void Collectable()
    {

    }

    void TakeDamage()
    {

    }
    void Died()
    {

    }
    void LoadNextLevel()
    {
        EditorGUILayout.PropertyField(nextLevel_Prop, new GUIContent("Next Level Scene Name"));
    }
}
