using AR;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UiDisplayButton : MonoBehaviour
    {
        private Image m_Image;
        private Button m_Button;
        private TextMeshProUGUI m_Name;
        private GameObject m_Prefab;
        private GameObject m_Ui;

        private void Awake()
        {
            m_Image = GetComponent<Image>();
            m_Button = GetComponent<Button>();
            m_Name = GetComponentInChildren<TextMeshProUGUI>();

            m_Button.onClick.AddListener(OnClick);
        }

        public void Init(MachineScriptableObject machine, GameObject ui)
        {
            m_Image.sprite = machine.display;
            m_Name.text = machine.name;
            m_Prefab = machine.prefab;
            m_Ui = ui;
        }

        private void OnClick()
        {
            ArManager.Instance.SetObjectToInstantiate(m_Prefab);
            m_Ui.SetActive(false);
        }
    }
}
