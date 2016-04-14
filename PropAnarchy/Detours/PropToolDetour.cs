using System;
using System.Reflection;
using PropAnarchy.Redirection;
using UnityEngine;

namespace PropAnarchy.Detours
{
    [TargetType(typeof(PropTool))]
    public class PropToolDetour
    {
        private static RedirectCallsState _state;
        private static IntPtr _originalPtr = IntPtr.Zero;
        private static IntPtr _detourPtr = IntPtr.Zero;

        private static MethodInfo _detourInfo = typeof(PropToolDetour).GetMethod("CheckPlacementErrors", BindingFlags.Public|BindingFlags.Static);
        private static bool _deployed;

        public static void Deploy()
        {
            if (_deployed)
            {
                return;
            }
            var tuple = RedirectionUtil.RedirectMethod(typeof(PropTool), _detourInfo);
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
        public static ToolBase.ToolErrors CheckPlacementErrors(PropInfo info, Vector3 position, bool fixedHeight, ushort id, ulong[] collidingSegmentBuffer, ulong[] collidingBuildingBuffer)
        {
            return ToolBase.ToolErrors.None;
        }
    }
}