using Hamlet.Game.Runtime.Buildings;
using Hamlet.Game.Runtime.Player;
using UnityEngine;

namespace Hamlet.Game.Runtime.PNJs
{
    [System.Serializable]
    public class PNJ : ISellable, ICollector
    {
        [field: SerializeField]
        public WorkData Data { get; private set; }

        [field: SerializeField]
        public float Multiplier { get; private set; }

        [field: SerializeField]
        public int SellPrice { get; private set; }

        [field: SerializeField]
        public ToolPNJ Tool { get; private set; }
        [field: SerializeField]
        public string Name;
        [field: SerializeField]
        public int BattlePower;
        [field: SerializeField]
        public int ID;
        int ISellable.sellPrice => SellPrice;

        IInventoryItem ISellable.resource => Inventory.Instance.Gold;

        public PNJ(string name, WorkData data, float multiplier, int sellPrice, int iD, int battlePower)
        {
            BattlePower = battlePower;
            Name = name;
            Data = data;
            Multiplier = multiplier;
            SellPrice = sellPrice;
            ID = iD;


        }



        public float GetMultiplierForResource(ResourceData resourceData)
        {
            if (Data.resource == resourceData)
                return Multiplier;
            else
                return 1;
        }
    }

}
