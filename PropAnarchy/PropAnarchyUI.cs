using ColossalFramework.UI;
using PropAnarchy.OptionsFramework;
using UnityEngine;

namespace PropAnarchy
{
    public class PropAnarchyUI : MonoBehaviour
    {
        private static string On => Mod.translation.GetTranslation("PTA_ON");

        private static string Off => Mod.translation.GetTranslation("PTA_OFF");

        private UILabel _label;

        public void Awake()
        {
            _label = GameObject.Find("OptionsBar").GetComponent<UIPanel>().AddUIComponent<UILabel>();
            _label.relativePosition += new Vector3(-100, 0 , 0);
        }

        public void OnDestroy()
        {
            Destroy(_label.gameObject);
        }

        public void Update()
        {
            if (OptionsWrapper<Options>.Options.noUi)
            {
                _label.Hide();
            }
            if (OptionsWrapper<Options>.Options.anarchyAlwaysOn)
            {
                DetoursManager.Deploy(true);
                SetupText();
                return;
            }
            if (!OptionsWrapper<Options>.Options.noUi)
            {
                _label.Show();
                SetupText();
            }
            if (!InputUtil.IsComboPressed())
            {
                return;
            }
            if (DetoursManager.IsDeployed())
            {
                DetoursManager.Revert(true);
            }
            else
            {
                DetoursManager.Deploy(true);
            }
        }

        //performed each frame
        public void SetupText()
        {
            if (_label == null || !_label.isVisible)
            {
                return;
            }
            _label.text = DetoursManager.IsDeployed()? On : Off;
         }
}
}