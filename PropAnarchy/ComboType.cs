using System.ComponentModel;

namespace PropAnarchy
{
    public enum ComboType
    {
        [Description("Shift+P")]
        ShiftP = 0,
        [Description("Ctrl+P")]
        CtrlP = 1,
        [Description("Alt+P")]
        AltP = 2
    }
}