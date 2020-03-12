using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Machine", menuName = "ScriptableObjects/MachineScriptableObject", order = 1)]
    public class MachineScriptableObject : ScriptableObject
    {
        public new string name;
        public ProductType type;
        public Sprite display;
        public GameObject prefab;

        public string description;
    }

    public enum ProductType
    {
        PressBrakes,
        Shears,
        Am
    }
}
