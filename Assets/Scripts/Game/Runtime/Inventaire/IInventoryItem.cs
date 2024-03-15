using Hamlet.Game.Runtime.PNJs;
using Hamlet.Game.Runtime.Player;

namespace Hamlet.Game.Runtime.Player
{
    /// <summary>
    /// Item stocké dans l'inventaire
    /// </summary>
    public interface IInventoryItem
    {
        string Name { get; }
    }
}