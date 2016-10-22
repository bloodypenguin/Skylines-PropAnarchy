using System;
using System.Threading;

namespace PropAnarchy
{
    public static class PropAnarchyHook
    {
        private static bool _initialDetourState;
        private static readonly object ClassLock = new object();
        private static int _currentThread;
        public static void ImUpToNoGood()
        {
            lock(ClassLock)
            {
                if (_currentThread != -1)
                {
                    UnityEngine.Debug.LogError("Prop Anarchy - PropAnarchyHook::ImUpToNoGood() - _currentThread wasn't null");
                    throw new Exception("Some other code already is using prop anarchy hook. Make sure all calls happen in the simulation thread");
                }
                _currentThread = Thread.CurrentThread.ManagedThreadId;
                _initialDetourState = DetoursManager.Deploy();
            }
        }

        public static void MischiefManaged()
        {
            lock (ClassLock)
            {
                    if (_currentThread != Thread.CurrentThread.ManagedThreadId)
                    {
                        UnityEngine.Debug.LogError("Prop Anarchy - PropAnarchyHook::MischiefManaged() - current thread no equal _currentThread");
                        throw new Exception("Some other code already is using prop anarchy hook. Make sure all calls happen in the simulation thread");
                    }
                    if (!_initialDetourState)
                    {
                        return;
                    }
                    DetoursManager.Revert();
                _currentThread = -1;
            }
        }

    }
}