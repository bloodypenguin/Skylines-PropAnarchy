using System;
using System.Reflection;
using PropAnarchy.Redirection;
using UnityEngine;

namespace PropAnarchy.Detours
{
    [TargetType(typeof(TreeInstance))]
    public class TreeInstanceDetour
    {
        private static RedirectCallsState _state;
        private static IntPtr _originalPtr = IntPtr.Zero;
        private static IntPtr _detourPtr = IntPtr.Zero;

        private static MethodInfo _detourInfo = typeof(TreeInstanceDetour).GetMethod("set_GrowState");
        private static bool _deployed;

        public static void Deploy()
        {
            if (_deployed)
            {
                return;
            }
            var tuple = RedirectionUtil.RedirectMethod(typeof(TreeInstance), _detourInfo);
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
        public static void set_GrowState(ref TreeInstance tree, int value)
        {
            if (value == 0)
            {
                return;
            }
            tree.m_flags = (ushort)((int)tree.m_flags & -3841 | Mathf.Clamp(value, 0, 15) << 8);
        }
    }
}