using Hamlet.Game.Runtime.Buildings.UI;
using Hamlet.Game.Runtime.Player;
using Hamlet.Game.Runtime.PNJs;
using UnityEngine;

namespace Hamlet.Game.Runtime
{
    public class PNJSummon : MonoBehaviour
    {
        public WorkData[] workDatas;
        public GameObject slotPrefab;

        public void SummonPNJ()
        {
            int rollData = Random.Range(0, workDatas.Length);
            float rollMultiplier = Random.Range(0, 31) / 10.0f;
            int rollSellPrice;

            if (rollMultiplier > 1)
            {
                rollSellPrice = 2;
            }
            else
            {
                rollSellPrice = 1;
            }
            int rollBattlePower = Random.Range(0, 100);

            int pnjID = Inventory.Instance.Pnjs.Count;
            PNJ pNJInstance = new(workDatas[rollData].WorkName, workDatas[rollData], rollMultiplier, rollSellPrice, pnjID, rollBattlePower);
            GameObject s = Instantiate(slotPrefab, Inventory.Instance.slotParent);
            s.GetComponent<PNJInventorySlot>().Bind(pNJInstance);
            Inventory.Instance.AddPNJToInventory(pNJInstance);


        }
    }
}
