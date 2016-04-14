using PropAnarchy.Redirection;
using UnityEngine;

namespace PropAnarchy.Detours
{
    [TargetType(typeof(TreeTool))]
    public class TreeToolDetour
    {
        [RedirectMethod]
        public static ToolBase.ToolErrors CheckPlacementErrors(TreeInfo info, Vector3 position, bool fixedHeight, ushort id, ulong[] collidingSegmentBuffer, ulong[] collidingBuildingBuffer)
        {
            return ToolBase.ToolErrors.None;
        }
    }
}