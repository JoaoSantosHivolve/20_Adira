using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PopulateProductsDisplay : MonoBehaviour
    {

        public GameObject ui;
        [Header("Grid Elements")]
        public UiDisplayButton prefab;
        public RectTransform scrollView;
        public GridLayoutGroup grid;

        private List<UiDisplayButton> m_GridElements = new List<UiDisplayButton>(); 

        public void Start()
        {
            Populate(MachinesManager.Instance.machines);
        }

        private void Populate(IEnumerable<MachineScriptableObject> machines)
        {
            ClearGrid();

            var width = scrollView.rect.width;
            grid.cellSize = new Vector2(width, width / 3);

            foreach (var machine in machines)
            {
                var display = Instantiate(prefab, transform);
                display.Init(machine, ui);

                m_GridElements.Add(display);
            }
        }

        public void SetDisplays(int index)
        {
            switch (index)
            {
                case 0:
                    Populate(MachinesManager.Instance.machines);
                    break;
                case 1:
                    Populate(MachinesManager.Instance.GetMachinesOfType(ProductType.PressBrakes));
                    break;
                case 2:
                    Populate(MachinesManager.Instance.GetMachinesOfType(ProductType.Shears));
                    break;
                case 3:
                    Populate(MachinesManager.Instance.GetMachinesOfType(ProductType.Am));
                    break;
            }
        }

        private void ClearGrid()
        {
            if (m_GridElements == null || m_GridElements.Count == 0)
                return;

            foreach (var element in m_GridElements)
                Destroy(element.gameObject);

            m_GridElements = new List<UiDisplayButton>();
        }
    }
}
