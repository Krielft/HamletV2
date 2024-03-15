using System;
using UnityEngine;

namespace LTX.Internal
{
    public class BaseSingleton<T, TFactory, TFinder> : IDisposable, ISingleton
        where T : ISingleton
        where TFactory : ISingletonFactory<T>, new()
        where TFinder : ISingletonFinder<T>, new()
    {
        
        private static TFactory _factory;
        protected static TFactory Factory => _factory??=new();
        
        private static TFinder _finder;
        protected static TFinder Finder => _finder??=new();
        
        
        private static object m_Lock = new object();
        protected static T instance;

        public static bool HasInstance => instance != null || Finder.TryFindExistingInstance(out instance);
        public virtual bool IsInstance => HasInstance && instance.Equals(this);
        
        
        /// <summary>
        /// Singleton
        /// </summary>
        public static T Instance
        {
            get
            {
                if (!Application.isPlaying)
                {
                    Debug.LogWarning("[Singleton] Instance" + typeof(T) + " already destroyed. Returning null");
                    return default;
                }

                lock (m_Lock)
                {
                    if (!HasInstance)
                    {
                        //Try finding an existing instance 
                        if (!Finder.TryFindExistingInstance(out instance))
                        {
                            //If none was found, a new fresh instance is created with the factory
                            instance = Factory.CreateSingleton();
                        }
                        
                        return instance;
                    }
                    return instance;
                }
            }
        }
        

        public virtual void Dispose()
        {
            if (IsInstance)
            {
                instance = default;
            }
        }
    }
}