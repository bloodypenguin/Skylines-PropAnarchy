using System;
using PropAnarchy.OptionsFramework;
using UnityEngine;

namespace PropAnarchy
{
    public static class InputUtil
    {
        public static bool IsComboPressed()
        {
            switch ((ComboType)OptionsWrapper<Options>.Options.keyCombo)
            {
                case ComboType.ShiftP:
                    if ((!Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftShift)) || !Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                    {
                        return false;
                    }
                    break;
                case ComboType.CtrlP:
                    if ((!Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftControl)) || !Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    {
                        return false;
                    }
                    break;
                case ComboType.AltP:
                    if ((!Input.GetKey(KeyCode.RightAlt) && !Input.GetKey(KeyCode.LeftAlt)) || !Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    {
                        return false;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return true;
        }
    }
}