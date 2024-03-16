using Hamlet.Game.Runtime.Player;
using UnityEngine;

namespace Hamlet.Game.Runtime
{
    [CreateAssetMenu(menuName = "Hamlet/BuildingUpgradeData")]
    public class UpgradeData : ScriptableObject
    {
        public ResourceData wood;
        public ResourceData stone;
        public ResourceData gold;





        public int baseCostClickValue;
        public int baseCostAutoCollect;
        public int baseCostSlots;
        public int baseCostTier;

        public float multiplierClickValue;
        public float multiplierSlots;
        public float multiplierAutoCollect;
        public float multiplierTier;
    }
}
