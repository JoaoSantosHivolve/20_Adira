using ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(MachinesManager))]
    public class MachinesManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var manager = (MachinesManager) target;

            if (GUILayout.Button("Organize List ABC"))
            {
                manager.OrganizeListAbc();
            }
            if (GUILayout.Button("Organize List Type"))
            {
                manager.OrganizeListType();
            }
        }
    }
}
