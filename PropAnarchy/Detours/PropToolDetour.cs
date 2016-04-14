using PropAnarchy.Redirection;
using UnityEngine;

namespace PropAnarchy.Detours
{
    [TargetType(typeof(PropTool))]
    public class PropToolDetour
    {
       
        [RedirectMethod]
        public static ToolBase.ToolErrors CheckPlacementErrors(PropInfo info, Vector3 position, bool fixedHeight, ushort id, ulong[] collidingSegmentBuffer, ulong[] collidingBuildingBuffer)
        {
            return ToolBase.ToolErrors.None;
        }
    }
}