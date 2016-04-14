using System;
using System.Reflection;
using PropAnarchy.Redirection;

namespace PropAnarchy.Detours
{
    [TargetType(typeof(PropInstance))]
    public class PropInstanceDetour
    {
        private static RedirectCallsState _state;
        private static IntPtr _originalPtr = IntPtr.Zero;
        private static IntPtr _detourPtr = IntPtr.Zero;

        private static MethodInfo _detourInfo = typeof(PropInstanceDetour).GetMethod("set_Blocked");
        private static bool _deployed;

        public static void Deploy()
        {
            if (_deployed)
            {
                return;
            }
            var tuple = RedirectionUtil.RedirectMethod(typeof(PropInstance), _detourInfo);
            _originalPtr = tuple.First.MethodHandle.GetFunctionPointer();
            _detourPtr = _detourInfo.MethodHandle.GetFunctionPointer();
            _state = tuple.Second;
            _deployed = true;
        }

        public static void Revert()
        {
            if (!_deployed) return;
            if (_originalPtr != IntPtr.Zero && _detourPtr != IntPtr.Zero)
            {
                RedirectionHelper.RevertJumpTo(_originalPtr, _state);
            }
            _deployed = false;
        }

        [RedirectMethod]
        public static void set_Blocked(ref PropInstance prop, bool value)
        {
            if (!value)
                prop.m_flags = (ushort)((uint)prop.m_flags & 4294967231U);
        }
    }
}