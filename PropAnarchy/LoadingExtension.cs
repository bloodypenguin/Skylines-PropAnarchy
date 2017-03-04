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
            DetoursManager.Deploy(false);
        }


        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            if (OptionsWrapper<Options>.Options.anarchyAlwaysOn || OptionsWrapper<Options>.Options.anarchyOnByDefault)
            {
                DetoursManager.Deploy(true);
            }
            else
            {
                DetoursManager.Revert(true);
            }
            new GameObject("PropAnarchy").AddComponent<PropAnarchyUI>();
        }

        public override void OnLevelUnloading()
        {
            DetoursManager.Revert(true);
            DetoursManager.Deploy(false); //to save the trees on reloading
            var go = GameObject.Find("PropAnarchy");
            if (go != null)
            {
                Object.Destroy(go);
            }
        }

        public override void OnReleased()
        {
            base.OnReleased();
            DetoursManager.Revert(true);
        }
    }
}