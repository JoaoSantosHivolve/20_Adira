using System;
using ScriptableObjects;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(MachineScriptableObject))]
    public class MachineScriptableObjectEditor : UnityEditor.Editor
    {
        private const string Name = "name";
        private const string Type = "type";
        private const string Display = "display";
        private const string Prefab = "prefab";

        private SerializedProperty m_Name;
        private SerializedProperty m_Type;
        private SerializedProperty m_Display;
        private SerializedProperty m_Prefab;

        public bool showDescription;

        private void OnEnable()
        {
            m_Name = serializedObject.FindProperty(Name);
            m_Type = serializedObject.FindProperty(Type);
            m_Display = serializedObject.FindProperty(Display);
            m_Prefab = serializedObject.FindProperty(Prefab);
        }

        public override void OnInspectorGUI()
        {
            // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
            serializedObject.Update();

            EditorGUILayout.LabelField("- Machine Info");

            EditorGUILayout.PropertyField(m_Name);
            EditorGUILayout.PropertyField(m_Type);
            EditorGUILayout.PropertyField(m_Display);
            EditorGUILayout.PropertyField(m_Prefab);


            showDescription = EditorGUILayout.Foldout(showDescription, "Description");

            var offsetProperty = serializedObject.FindProperty("description");
            if (showDescription)
            {
                EditorGUILayout.PropertyField(offsetProperty);
            }


            // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
            serializedObject.ApplyModifiedProperties();
        }
    }
}
