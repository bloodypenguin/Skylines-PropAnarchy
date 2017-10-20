using System.Runtime.CompilerServices;
using ColossalFramework;
using ColossalFramework.Math;
using PropAnarchy.OptionsFramework;
using PropAnarchy.Redirection;
using UnityEngine;

namespace PropAnarchy.Detours
{
    [TargetType(typeof(PropInstance))]
    public class PropInstanceDetour
    {
        [RedirectMethod]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void set_Blocked(ref PropInstance prop, bool value)
        {
            if (!value)
                prop.m_flags = (ushort)((uint)prop.m_flags & 4294967231U);
        }

        [RedirectMethod]
        private static void CheckOverlap(ref PropInstance prop, ushort propID) //this method reproduces original code for most part to prevent exceptions
        {
            PropInfo info = prop.Info;
            if (info == null)
                return;
            ItemClass.CollisionType collisionType = ((int)prop.m_flags & 32) != 0 ? ItemClass.CollisionType.Elevated : ItemClass.CollisionType.Terrain;
            Randomizer randomizer = new Randomizer((int)propID);
            float num1 = info.m_minScale + (float)((double)randomizer.Int32(10000U) * ((double)info.m_maxScale - (double)info.m_minScale) * 9.99999974737875E-05);
            float num2 = info.m_generatedInfo.m_size.y * num1;
            Vector3 position = prop.Position;
            float minY = position.y;
            float maxY = position.y + num2;
            float num3 = !prop.Single ? 4.5f : 0.3f;
            Quad2 quad = new Quad2();
            Vector2 vector2 = VectorUtils.XZ(position);
            quad.a = vector2 + new Vector2(-num3, -num3);
            quad.b = vector2 + new Vector2(-num3, num3);
            quad.c = vector2 + new Vector2(num3, num3);
            quad.d = vector2 + new Vector2(num3, -num3);
            bool flag = false;
            if (info.m_class != null)
            {
                if (Singleton<NetManager>.instance.OverlapQuad(quad, minY, maxY, collisionType, info.m_class.m_layer, (ushort)0, (ushort)0, (ushort)0))
                    flag = true;
                if (Singleton<BuildingManager>.instance.OverlapQuad(quad, minY, maxY, collisionType, info.m_class.m_layer, (ushort)0, (ushort)0, (ushort)0))
                    flag = true;
            }
            //begin mod
            if (!OptionsWrapper<Options>.Options.unhideAllPropsOnLevelLoading)
            {
                return;
            }
            prop.Blocked = false;
            //end mod
        }
    }
}