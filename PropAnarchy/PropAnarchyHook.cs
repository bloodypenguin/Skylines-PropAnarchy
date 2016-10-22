using System;
using System.Threading;
using PropAnarchy.OptionsFramework;

namespace PropAnarchy
{
    public static class PropAnarchyHook
    {
        private static readonly object ClassLock = new object();

        internal static volatile bool _wasAnarchyEnabled;
        private static volatile int _currentThread = -1;
        public static void ImUpToNoGood()
        {
            UnityEngine.Debug.Log("ImUpToNoGood");
            lock (ClassLock)
            {
                if (_currentThread != -1)
                {
                    UnityEngine.Debug.LogError("Prop Anarchy - PropAnarchyHook::ImUpToNoGood() - _currentThread wasn't null");
                    throw new Exception("Some other code already is using prop anarchy hook. Make sure all calls happen in the simulation thread");
                }
                _currentThread = Thread.CurrentThread.ManagedThreadId;
                _wasAnarchyEnabled = !DetoursManager.Deploy();
            }
        }

        public static void MischiefManaged()
        {
            UnityEngine.Debug.Log("MischiefManaged");
            lock (ClassLock)
            {
                if (_currentThread != Thread.CurrentThread.ManagedThreadId)
                {
                    UnityEngine.Debug.LogError("Prop Anarchy - PropAnarchyHook::MischiefManaged() - current thread no equal _currentThread");
                    throw new Exception("Some other code already is using prop anarchy hook. Make sure all calls happen in the simulation thread");
                }
                if (_wasAnarchyEnabled)
                {
                    _currentThread = -1;
                    return;
                }
                DetoursManager.Revert();
                _currentThread = -1;
            }
        }

    }
}