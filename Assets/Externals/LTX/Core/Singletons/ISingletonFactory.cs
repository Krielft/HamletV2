using LTX.Internal;

namespace LTX
{
    public interface ISingletonFactory<out T> where T : ISingleton
    {
        public T CreateSingleton();
    }
}