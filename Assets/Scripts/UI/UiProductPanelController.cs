using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UiProductPanelController : MonoBehaviour
    {
        [Header("Grid that contains all displays")]
        public PopulateProductsDisplay displayGrid;
        [Header("Button that opens/closes the panel:")]
        public Animator panelButton;
        [Header("List of buttons on panel:")]
        public List<Button> buttons;

        private Animator m_Animator;
        private int m_SectionIndex;
        private static readonly int Open = Animator.StringToHash("Open");

        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
            m_SectionIndex = 0;
        }

        public void OnClick_TogglePanel()
        {
            m_Animator.SetBool(Open, !m_Animator.GetBool(Open));
            panelButton.SetBool(Open, m_Animator.GetBool(Open));

            SetButton(buttons[m_SectionIndex], m_Animator.GetBool(Open));
        }

        public void OnClick_Button(int index)
        {
            for (var i = 0; i < buttons.Capacity; i++)
            {
                SetButton(buttons[i], i == index);
            }

            m_SectionIndex = index;

            displayGrid.SetDisplays(index);
        }

        private static void SetButton(Component button, bool state)
        {
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = state ? Color.white : Color.black;
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = state ? FontStyles.Underline : FontStyles.Normal;
        }
    }
}