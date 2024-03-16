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


        private int lvlClickCap = 1;
        private int lvlAutoCap = 0;
        private int lvlSlotsCap = 0;

        private int tier = 1;
        public void TriggerUpdateButton(string upgradeName)
        {
            switch (upgradeName)
            {
                case "Click":
                    UpgradeLevel(UpgradeType.NmbrResourceClick);
                    break;
                case "Auto":
                    UpgradeLevel(UpgradeType.NmbrResourceAutoSec); break;

                case "Slots":
                    UpgradeLevel(UpgradeType.SlotsPNJs); break;
                case "Tier":
                    UpgradeLevel(UpgradeType.tier);
                    break;

            }
        }
        public void UpgradeLevel(UpgradeType type)
        {
            CheckCost(type);
            switch (type)
            {
                case UpgradeType.NmbrResourceClick:
                    if (lvlClickCollect < lvlClickCap)
                    {
                        if (
                                            Inventory.Instance.HasEnoughResources(UpgradeData.wood, (costClickCollect * 12) / 10)
                                             && Inventory.Instance.HasEnoughResources(UpgradeData.stone, costClickCollect))
                        {
                            Inventory.Instance.RemoveItem(UpgradeData.wood, (costClickCollect * 12) / 10);
                            Inventory.Instance.RemoveItem(UpgradeData.stone, (costClickCollect));
                            lvlClickCollect += 1;
                            NmbrResourceClickvalue += (NmbrResourceClickvalue * lvlClickCollect);

                        }
                    }

                    break;
                case UpgradeType.NmbrResourceAutoSec:
                    if (lvlAutoCollect < lvlAutoCap)
                    {
                        if (
                    Inventory.Instance.HasEnoughResources(UpgradeData.wood, (costAutoCollect * 12) / 10)
                    && Inventory.Instance.HasEnoughResources(UpgradeData.stone, costAutoCollect))
                        {
                            Inventory.Instance.RemoveItem(UpgradeData.wood, (costAutoCollect * 12) / 10);
                            Inventory.Instance.RemoveItem(UpgradeData.stone, (costAutoCollect));
                            lvlAutoCollect += 1;
                            NmbrResourceAutoSecvalue += (NmbrResourceAutoSecvalue * lvlAutoCollect);

                        }
                    }



                    break;
                case UpgradeType.SlotsPNJs:

                    if (lvlSlots < lvlSlotsCap)
                        if (Inventory.Instance.HasEnoughResources(UpgradeData.gold, costSlots))
                        {
                            Inventory.Instance.RemoveItem(UpgradeData.gold, costSlots);
                            lvlSlots += 1;
                            SlotsPNJsvalue += 1;

                        }

                    break;
                case UpgradeType.tier:
                    if (lvlSlotsCap == lvlSlots && lvlClickCap == lvlClickCollect && lvlAutoCap == lvlAutoCollect && tier != 3)
                    {

                        if (
                            Inventory.Instance.HasEnoughResources(UpgradeData.wood, costTier) &&
                            Inventory.Instance.HasEnoughResources(UpgradeData.stone, (int)(costTier * 0.8f)) &&
                            Inventory.Instance.HasEnoughResources(UpgradeData.gold, (int)(costTier * 1.1f))
                            )
                        {
                            Inventory.Instance.RemoveItem(UpgradeData.wood, costTier);
                            Inventory.Instance.RemoveItem(UpgradeData.stone, (int)(costTier * 0.8f));
                            Inventory.Instance.RemoveItem(UpgradeData.gold, (int)(costTier * 1.1f));
                            tier += 1;
                            lvlClickCap += 10;
                            lvlAutoCap += 10;
                            lvlSlotsCap += 5;
                        }
                    }
                    break;
            }
        }



        private int costClickCollect;
        private int costAutoCollect;
        private int costSlots;
        private int costTier;
        public void CheckCost(UpgradeType type)
        {
            switch (type)
            {
                case UpgradeType.NmbrResourceClick:
                    costClickCollect = (int)(UpgradeData.baseCostClickValue * UpgradeData.multiplierClickValue * (2 * lvlClickCollect));
                    break;
                case UpgradeType.NmbrResourceAutoSec:
                    costAutoCollect = (int)(UpgradeData.baseCostAutoCollect * UpgradeData.multiplierAutoCollect * (3 * lvlAutoCollect));
                    break;
                case UpgradeType.SlotsPNJs:
                    costSlots = (int)(UpgradeData.baseCostSlots * UpgradeData.multiplierSlots * (4 * lvlSlots));
                    break;
                case UpgradeType.tier:
                    costTier = (int)(UpgradeData.baseCostTier * UpgradeData.multiplierTier * (3.5f * (lvlAutoCollect + lvlClickCollect + lvlSlots)));
                    break;
            }
        }




    }
}
