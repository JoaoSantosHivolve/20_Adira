using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Common;

namespace ScriptableObjects
{
    public class MachinesManager : Singleton<MachinesManager>
    {
        public List<MachineScriptableObject> machines;

        public List<MachineScriptableObject> GetMachinesOfType(ProductType type)
        {
            var newList = new List<MachineScriptableObject>();

            foreach (var machine in machines)
                if(machine.type == type)
                    newList.Add(machine);

            return newList;
        }

        public void OrganizeListAbc()
        {
            machines = machines.OrderBy(tile => tile.name).ToList();
        }
        public void OrganizeListType()
        {
            machines = machines.OrderBy(tile => tile.type).ToList();
        }

    }
}
