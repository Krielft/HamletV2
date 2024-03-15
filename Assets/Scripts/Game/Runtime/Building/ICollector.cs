using Hamlet.Game.Runtime.Player;

namespace Hamlet.Game.Runtime.Buildings
{

    /// <summary>
    /// Collecte des resources dans un batiment
    /// </summary>
    public interface ICollector
    {
        float GetMultiplierForResource(ResourceData resourceData);
    }
}