using System;
using System.Reflection;
using PropAnarchy.Redirection;
using UnityEngine;

namespace PropAnarchy.Detours
{
    [TargetType(typeof(TreeTool))]
    public class TreeToolDetour
    {
        private static RedirectCallsState _state;
        private static IntPtr _originalPtr = IntPtr.Zero;
        private static IntPtr _detourPtr = IntPtr.Zero;

        private static MethodInfo _detourInfo = typeof(TreeToolDetour).GetMethod("CheckPlacementErrors", BindingFlags.Public|BindingFlags.Static);
        private static bool _deployed;

        public static void Deploy()
        {
            if (_deployed)
            {
                return;
            }
            var tuple = RedirectionUtil.RedirectMethod(typeof(TreeTool), _detourInfo);
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
        public static ToolBase.ToolErrors CheckPlacementErrors(TreeInfo info, Vector3 position, bool fixedHeight, ushort id, ulong[] collidingSegmentBuffer, ulong[] collidingBuildingBuffer)
        {
            return ToolBase.ToolErrors.None;
        }
    }
}