using System;
using System.Threading;
using PropAnarchy.OptionsFramework;

namespace PropAnarchy
{
    public static class PropAnarchyHook
    {
        private static readonly object ClassLock = new object();

        private static volatile int _currentThread = -1;
        public static void ImUpToNoGood(string modName)
        {
            UnityEngine.Debug.Log($"Prop Anarchy - enable prevent props & trees from disappearing ({modName})");
            lock (ClassLock)
            {
                if (_currentThread != -1)
                {
                    UnityEngine.Debug.LogError("Prop Anarchy - PropAnarchyHook::ImUpToNoGood() - _currentThread wasn't null");
                    throw new Exception("Some other code is already using prop anarchy hook. Make sure all calls happen in the simulation thread");
                }
                _currentThread = Thread.CurrentThread.ManagedThreadId;
                DetoursManager.Deploy(false);
            }
        }

        public static void MischiefManaged(string modName)
        {
            UnityEngine.Debug.Log($"Prop Anarchy - disable prevent props & trees from disappearing ({modName})");
            lock (ClassLock)
            {
                if (_currentThread != Thread.CurrentThread.ManagedThreadId)
                {
                    UnityEngine.Debug.LogError("Prop Anarchy - PropAnarchyHook::MischiefManaged() - current thread no equal to _currentThread");
                    throw new Exception("Some other code is already using prop anarchy hook. Make sure all calls happen in the simulation thread");
                }
                if (!DetoursManager.GetCachedDeployedState())
                {
                    DetoursManager.Revert(false);
                }
                _currentThread = -1;
            }
        }

    }
}