using Hamlet.Game.Runtime.Player;
using UnityEngine;

namespace Hamlet.Game.Runtime
{
    [CreateAssetMenu(menuName = "Hamlet/BuildingUpgradeData")]
    public class UpgradeData : ScriptableObject
    {
        public int coeffclickValue;
        public int coeffSlots;
        public int coeffAutoCollect;

        public ResourceData dataClickValue1;
        public ResourceData dataClickValue2;

        public ResourceData dataAutoCollect1;
        public ResourceData dataAutoCollect2;
        public ResourceData dataSlots;


        public int baseCostClickValue;
        public int baseCostAutoCollect;
        public int baseCostSlots;

        public int multiplierClickValue;
        public int multiplierSlots;
        public int multiplierAutoCollect;
    }
}
