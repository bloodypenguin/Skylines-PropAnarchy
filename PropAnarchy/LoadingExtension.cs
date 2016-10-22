using ICities;
using PropAnarchy.OptionsFramework;
using UnityEngine;

namespace PropAnarchy
{
    public class LoadingExtension : LoadingExtensionBase
    {

        public override void OnCreated(ILoading loading)
        {
            base.OnCreated(loading);
            DetoursManager.Deploy();
        }


        public override void OnLevelLoaded(LoadMode mode)
        {
            if (!OptionsWrapper<Options>.Options.anarchyAlwaysOn && !OptionsWrapper<Options>.Options.anarchyOnByDefault)
            {
                DetoursManager.Revert();
                PropAnarchyHook._wasAnarchyEnabled = false;
            }
            new GameObject("PropAnarchy").AddComponent<PropAnarchyUI>();
        }

        public override void OnLevelUnloading()
        {
            DetoursManager.Deploy(); //to save the trees on reloading
            var go = GameObject.Find("PropAnarchy");
            if (go != null)
            {
                Object.Destroy(go);
            }
        }

        public override void OnReleased()
        {
            base.OnReleased();
            DetoursManager.Revert();
        }
    }
}