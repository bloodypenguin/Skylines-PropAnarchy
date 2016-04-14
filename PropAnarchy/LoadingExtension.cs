using ICities;
using UnityEngine;
using static UnityEngine.Object;

namespace PropAnarchy
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            DetoursUtil.Deploy();
            new GameObject("PropAnarchy").AddComponent<PropAnarchyUI>();
        }

        public override void OnLevelUnloading()
        {
            DetoursUtil.Revert();
            var go = GameObject.Find("PropAnarchy");
            if (go != null)
            {
                Destroy(go);
            }
        }
    }
}