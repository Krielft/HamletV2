using Hamlet.Game.Runtime.Buildings.UI;
using Hamlet.Game.Runtime.Player;
using Hamlet.Game.Runtime.PNJs;
using NaughtyAttributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hamlet.Game.Runtime.Buildings
{
    public class Building : MonoBehaviour
    {
        [SerializeField]
        public BuildingData Data;
        [AllowNesting]
        public List<PNJ> Pnjs = new List<PNJ>(); // Utilisation d'une liste au lieu d'un tableau
        string BuildingName;

        int NmbrResourceClickvalue;
        int NmbrResourceAutoSecvalue;
        [SerializeField]
        public int SlotsPNJsvalue;
        ResourceData resourceData;



        private void Awake()
        {
            BuildingName = Data.BuildingName;
            NmbrResourceAutoSecvalue = Data.NmbrResourceAutoSecvalue;
            NmbrResourceClickvalue = Data.NmbrResourceClickvalue;
            SlotsPNJsvalue = Data.SlotsPNJsvalue;
            resourceData = Data.Data;
        }
        public List<PNJ> pnjInSelection = new List<PNJ>();
        public void UpdatePNJSInSelection()
        {
            pnjInSelection.Clear();
            Pnjs.Clear();
        }
        public void AddToBuilding()
        {
            MovePNJFromInventoryToBuilding(pnjInSelection);
            pnjInSelection.Clear();
            foreach (Transform child in Inventory.Instance.slotParent)
            {
                child.GetComponent<Image>().color = Color.white;
                child.GetComponent<PNJInventorySlot>().isSelected = false;
            }
        }
        public void MovePNJFromInventoryToBuilding(List<PNJ> listP)
        {
            Pnjs.Clear();
            Pnjs.AddRange(listP);
            foreach (Transform child in parentTransform)
            {
                // Destruction de chaque enfant
                DestroyImmediate(child.gameObject);
            }
            foreach (PNJ pnj in Pnjs)
            {
                GameObject sI = Instantiate(slotPnJInBuildingIconPrefab, parentTransform);
                sI.GetComponentInChildren<TextMeshProUGUI>().text = pnj.ID.ToString();
            }
        }

        public GameObject slotPnJInBuildingIconPrefab;
        public Transform parentTransform;

        public void Collect(string type)
        {
            switch (type)
            {
                case "ManualCollect":
                    Inventory.Instance.AddItem(resourceData, NmbrResourceClickvalue);
                    break;
                case "AutoCollect":
                    foreach (PNJ pNJ in Pnjs)
                    {
                        int quantity = Mathf.CeilToInt(NmbrResourceAutoSecvalue * pNJ.GetMultiplierForResource(resourceData));
                        Inventory.Instance.AddItem(resourceData, quantity);

                    }
                    break;
                default:
                    break;
            }
        }

        public UpgradeData UpgradeData;
        private int lvlClickCollect;
        private int lvlAutoCollect;
        private int lvlSlots;


        public int lvlClickCap = 1;
        private int lvlAutoCap = 0;
        private int lvlSlotsCap = 0;

        private int tier = 1;
        public void UpgradeLevel(UpgradeType type)
        {
            CheckCost(type);
            switch (type)
            {
                case UpgradeType.NmbrResourceClick:
                    if (
                    Inventory.Instance.HasEnoughResources(UpgradeData.dataClickValue1, (costClickCollect * 12) / 10)
                     && Inventory.Instance.HasEnoughResources(UpgradeData.dataClickValue2, costClickCollect))
                    {
                        Inventory.Instance.RemoveItem(UpgradeData.dataClickValue1, (costClickCollect * 12) / 10);
                        Inventory.Instance.RemoveItem(UpgradeData.dataClickValue2, (costClickCollect));
                        NmbrResourceClickvalue += UpgradeData.coeffclickValue;
                        lvlClickCollect += 1;

                    }
                    break;
                case UpgradeType.NmbrResourceAutoSec:
                    if (
                    Inventory.Instance.HasEnoughResources(UpgradeData.dataAutoCollect1, (costAutoCollect * 12) / 10)
                    && Inventory.Instance.HasEnoughResources(UpgradeData.dataAutoCollect2, costAutoCollect))
                    {
                        Inventory.Instance.RemoveItem(UpgradeData.dataAutoCollect1, (costAutoCollect * 12) / 10);
                        Inventory.Instance.RemoveItem(UpgradeData.dataAutoCollect2, (costAutoCollect));
                        NmbrResourceAutoSecvalue += UpgradeData.coeffAutoCollect;
                        lvlAutoCollect += 1;

                    }

                    break;
                case UpgradeType.SlotsPNJs:
                    if (Inventory.Instance.HasEnoughResources(UpgradeData.dataSlots, costSlots))
                    {
                        Inventory.Instance.RemoveItem(UpgradeData.dataSlots, costSlots);
                        SlotsPNJsvalue += UpgradeData.coeffSlots;
                        lvlSlots += 1;

                    }

                    break;
            }
        }



        private int costClickCollect;
        private int costAutoCollect;
        private int costSlots;
        public void CheckCost(UpgradeType type)
        {
            switch (type)
            {
                case UpgradeType.NmbrResourceClick:
                    costClickCollect = UpgradeData.baseCostClickValue * UpgradeData.multiplierClickValue * (2 * lvlClickCollect);
                    break;
                case UpgradeType.NmbrResourceAutoSec:
                    costAutoCollect = UpgradeData.baseCostAutoCollect * UpgradeData.multiplierAutoCollect * (3 * lvlAutoCollect);
                    break;
                case UpgradeType.SlotsPNJs:
                    costSlots = UpgradeData.baseCostSlots * UpgradeData.multiplierSlots * (4 * lvlSlots);
                    break;
            }
        }
        public void UpgradeTier()
        {

        }

        /* public float GetMultiplierForResource(ResourceData resourceData)
         {
             throw new System.NotImplementedException();
         }*/
    }
}
