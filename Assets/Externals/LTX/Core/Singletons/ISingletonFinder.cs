using LTX.Internal;

namespace LTX
{
    public interface ISingletonFinder<T> where T : ISingleton
    {
        public bool TryFindExistingInstance(out T instance);
    }
}