using ICities;
using UnityEngine;
using static UnityEngine.Object;

namespace PropAnarchy
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            var go = new GameObject("PropAnarchy");
            go.AddComponent<PropAnarchyUI>();
            go.AddComponent<ToolMonitor>();
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            var go = GameObject.Find("PropAnarchy");
            if (go != null)
            {
                Destroy(go);
            }
            DetoursManager.Revert();
        }
    }
}