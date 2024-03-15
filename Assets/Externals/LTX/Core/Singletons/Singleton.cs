using LTX.Internal;

namespace LTX
{
    public abstract class Singleton<T, TFactory, TFinder> : BaseSingleton<T, TFactory, TFinder>
        where T : ISingleton, new()
        where TFinder : ISingletonFinder<T>, new()
        where TFactory : ISingletonFactory<T>, new()
    {
        
    }
    
    public abstract class Singleton<T, TFactory> : Singleton<T, TFactory, SingletonFinder<T>>
        where TFactory : ISingletonFactory<T>, new()
        where T : ISingleton, new()
    {
        
    }
    public abstract class Singleton<T> : Singleton<T, SingletonFactory<T>, SingletonFinder<T>>
        where T : ISingleton, new()
    {
        
    }

    namespace Internal
    {
        public class SingletonFactory<T> : ISingletonFactory<T> where T : ISingleton, new()
        {
            public T CreateSingleton() => new();
        }

        public class SingletonFinder<T> : ISingletonFinder<T> where T : ISingleton
        {
            public bool TryFindExistingInstance(out T instance)
            {
                instance = default;
                return false;
            }
        }
    }
}