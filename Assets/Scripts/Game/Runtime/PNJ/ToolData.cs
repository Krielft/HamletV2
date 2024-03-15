using UnityEngine;
using Hamlet.Game.Runtime.Player;

namespace Hamlet.Game.Runtime.PNJs
{
    [CreateAssetMenu]
    public class ToolData : ScriptableObject, IInventoryItem
    {
        public WorkData work { get; private set; }

        


        ///public float multiplier { get; private set; }

        public string Name => Name;

        public ResourceData resourceData;
    }

}

