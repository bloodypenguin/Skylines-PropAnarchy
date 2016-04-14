using ColossalFramework.UI;
using UnityEngine;

namespace PropAnarchy
{
    public class PropAnarchyUI : MonoBehaviour
    {
        private const string ON = "Prop & Tree Anarchy: On";
        private const string OFF = "Prop & Tree Anarchy: Off";

        private UILabel label;
        private bool anarchyOn;

        public void Awake()
        {
            label = GameObject.Find("OptionsBar").GetComponent<UIPanel>().AddUIComponent<UILabel>();
            label.text = ON;
            anarchyOn = true;
        }

        public void OnDestroy()
        {
            Destroy(label.gameObject);
        }

        public void Update()
        {
            if ((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Input.GetKeyDown(KeyCode.P))
            {
                if (anarchyOn)
                {
                    DetoursUtil.Revert();
                    label.text = OFF;
                }
                else
                {
                    DetoursUtil.Deploy();
                    label.text = ON;
                }
                anarchyOn = !anarchyOn;
            }
        }
    }
}