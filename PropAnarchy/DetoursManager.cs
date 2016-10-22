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
        private static volatile bool _cachedDeployState = false;

        public static bool Deploy(bool cacheDeployState)
        {
            lock (ClassLock)
            {
                if (cacheDeployState)
                {
                    _cachedDeployState = true;
                }
                if (IsDeployed())
                {
                    return false;
                }
                _redirects = RedirectionUtil.RedirectAssembly();
                return true;
            }

        }

        public static void Revert(bool cacheDeployState)
        {
            lock (ClassLock)
            {
                if (cacheDeployState)
                {
                    _cachedDeployState = false;
                }
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

        public static bool GetCachedDeployedState()
        {
            lock (ClassLock)
            {
                return _cachedDeployState;
            }
        }

    }
}