using Hamlet.Game.Runtime.Player;
using UnityEngine;

namespace Hamlet.Game.Runtime
{
    [System.Serializable]
    public class Geode
    {
        public ResourceData resourceData;
        public int hp;

        [HideInInspector]
        public int maxHp;

        public bool TryCollect()
        {
            hp -= 1;
            return hp <= 0;
        }

        public void Collect()
        {
            Inventory.Instance.AddItem(resourceData, 1);
        }

        public void Reset()
        {
            hp = maxHp;
        }
    }
}
