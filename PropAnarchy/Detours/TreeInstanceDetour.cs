using System.Runtime.CompilerServices;
using ColossalFramework;
using ColossalFramework.Math;
using PropAnarchy.OptionsFramework;
using PropAnarchy.Redirection;
using UnityEngine;

namespace PropAnarchy.Detours
{
    [TargetType(typeof(TreeInstance))]
    public class TreeInstanceDetour
    {
        [RedirectMethod]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void set_GrowState(ref TreeInstance tree, int value)
        {
            if (value == 0)
            {
                return;
            }
            tree.m_flags = (ushort)((int)tree.m_flags & -3841 | Mathf.Clamp(value, 0, 15) << 8);
        }

        [RedirectMethod]
        private static void CheckOverlap(ref TreeInstance tree, uint treeID) //this method reproduces original code for most part to prevent exceptions
        {
            TreeInfo info = tree.Info;
            if (info == null)
                return;
            ItemClass.CollisionType collisionType = ((int)tree.m_flags & 32) != 0 ? ItemClass.CollisionType.Elevated : ItemClass.CollisionType.Terrain;
            Randomizer randomizer = new Randomizer(treeID);
            float num1 = info.m_minScale + (float)((double)randomizer.Int32(10000U) * ((double)info.m_maxScale - (double)info.m_minScale) * 9.99999974737875E-05);
            float num2 = info.m_generatedInfo.m_size.y * num1;
            Vector3 position = tree.Position;
            float minY = position.y;
            float maxY = position.y + num2;
            float num3 = !tree.Single ? 4.5f : 0.3f;
            Quad2 quad = new Quad2();
            Vector2 vector2 = VectorUtils.XZ(position);
            quad.a = vector2 + new Vector2(-num3, -num3);
            quad.b = vector2 + new Vector2(-num3, num3);
            quad.c = vector2 + new Vector2(num3, num3);
            quad.d = vector2 + new Vector2(num3, -num3);
            bool flag = false;
            if (Singleton<NetManager>.instance.OverlapQuad(quad, minY, maxY, collisionType, info.m_class.m_layer, (ushort)0, (ushort)0, (ushort)0))
                flag = true;
            if (Singleton<BuildingManager>.instance.OverlapQuad(quad, minY, maxY, collisionType, info.m_class.m_layer, (ushort)0, (ushort)0, (ushort)0))
                flag = true;
            //begin mod
            if (!OptionsWrapper<Options>.Options.unhideAllTreesOnLevelLoading)
            {
                return;
            }
            if (tree.GrowState != 0)
                return;
            tree.GrowState = 1;
            //end mod
        }
    }
}