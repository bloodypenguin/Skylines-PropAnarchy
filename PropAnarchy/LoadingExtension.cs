using ICities;

namespace PropAnarchy
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnCreated(ILoading loading)
        {
            base.OnCreated(loading);
            DetoursManager.Deploy();
        }

        public override void OnReleased()
        {
            base.OnReleased();
            DetoursManager.Revert();
        }
    }
}