using ColossalFramework.UI;
using PropAnarchy.OptionsFramework;
using UnityEngine;

namespace PropAnarchy
{
    public class PropAnarchyUI : MonoBehaviour
    {
        private const string On = "Prop & Tree Anarchy: On";
        private const string Off = "Prop & Tree Anarchy: Off";

        private UILabel _label;
        public bool AnarchyOn { get; private set; }
        private ToolBase cachedTool;

        public void Awake()
        {
            _label = GameObject.Find("OptionsBar").GetComponent<UIPanel>().AddUIComponent<UILabel>();
            _label.relativePosition += new Vector3(100.0f, -100.0f);
            _label.isVisible = false;
            AnarchyOn = OptionsWrapper<Options>.Options.anarchyOnByDefault;
            SetupText();
        }

        public void OnDestroy()
        {
            Destroy(_label.gameObject);
        }

        public void Update()
        {
            if (!_label.isVisible)
            {
                return;
            }
            if (OptionsWrapper<Options>.Options.resetAnarchyStateOnToolChange)
            {
                var currentTool = ToolsModifierControl.GetCurrentTool<ToolBase>();
                if (cachedTool != currentTool)
                {
                    cachedTool = currentTool;
                    AnarchyOn = OptionsWrapper<Options>.Options.anarchyOnByDefault;
                    SetupText();
                }
            }
            if (!Input.GetKey(KeyCode.RightShift) || !Input.GetKey(KeyCode.LeftShift) || !Input.GetKeyDown(KeyCode.P) ||
                Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                return;
            }
            AnarchyOn = !AnarchyOn;
            SetupText();
        }

        public void Show()
        {
            _label?.Show();
        }

        public void Hide()
        {
            _label?.Hide();
        }

        private void SetupText()
        {
            if (_label == null)
            {
                return;
            }
            _label.text = AnarchyOn ? On : Off;
        }
    }
}