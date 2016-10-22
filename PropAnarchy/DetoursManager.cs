using System;
using System.Collections.Generic;
using System.Reflection;
using PropAnarchy.Redirection;

namespace PropAnarchy
{
    public static class DetoursManager
    {
        private static Dictionary<MethodInfo, RedirectCallsState> _redirects;
        private static readonly object ClassLock = new object();


        public static bool Deploy()
        {
            lock (ClassLock)
            {
                if (IsDeployed())
                {
                    return false;
                }
                _redirects = RedirectionUtil.RedirectAssembly();
                return true;
            }

        }

        public static void Revert()
        {
            lock (ClassLock)
            {
                if (!IsDeployed())
                {
                    return;
                }
                if (_redirects == null)
                {
                    UnityEngine.Debug.LogError("Prop Anarchy - DetoursManager::Revert() - _redirects field was null");
                    return;
                }
                RedirectionUtil.RevertRedirects(_redirects);
                _redirects.Clear();
            }
        }

        public static bool IsDeployed()
        {
            lock (ClassLock)
            {
                return _redirects != null && _redirects.Count != 0;
            }
        }
    }
}