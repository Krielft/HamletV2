namespace Hamlet.Game.Runtime.Player
{
    public interface ISellable
    {
        int sellPrice { get; }
        IInventoryItem resource { get; }


    }
}

