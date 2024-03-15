using Hamlet.Game.Runtime.PNJs;
using LTX;
using NaughtyAttributes;
using System.Collections.Generic;

using UnityEngine;

namespace Hamlet.Game.Runtime.Player
{

    public class Inventory : MonoSingleton<Inventory>
    {
        public Transform slotParent;
        private ResourceData[] resourceDatas;
        [AllowNesting]
        public List<PNJ> Pnjs = new List<PNJ>(); // Utilisation d'une liste au lieu d'un tableau
        public List<Tool> Tools = new List<Tool>();
        public ResourceData Gold { get; private set; }
        private Dictionary<IInventoryItem, int> items;

        public GameObject actualBuilding;

        protected override void Awake()
        {
            base.Awake();
            items = new Dictionary<IInventoryItem, int>();
            resourceDatas = Resources.LoadAll<ResourceData>("ResourceData");
            for (int i = 0; i < resourceDatas.Length; i++)
            {
                if (resourceDatas[i].name == "Gold")
                {
                    Gold = resourceDatas[i];
                    break;
                }

                /*if (resourceDatas[i].name == "Iron")
                {
                    iron = resourceDatas[i];
                    break;
                }*/
            }
        }
        public void AddPNJToInventory(PNJ pnj)
        {
            Pnjs.Add(pnj);

        }

        public void AddToolToInventory(Tool tool)
        {
            Tools.Add(tool);
        }



        public void AddItem(IInventoryItem item, int quantity = 1)
        {
            if (items.TryGetValue(item, out var i))
                items[item] = i + quantity;
            else
                items.Add(item, quantity);

            Debug.Log($"added {quantity} to {item.Name}. quantity is {items[item]}");
        }

        public void RemoveItem(IInventoryItem item, int quantity = 1)
        {
            if (items.TryGetValue(item, out var i))
            {
                if (i <= quantity)
                    items.Remove(item);
                else
                    items[item] -= quantity;

            }
        }

        public bool TryGetItemQuantity(IInventoryItem item, out int quantity) => items.TryGetValue(item, out quantity);

        /*public GameObject pNJInventoryPanel;
        private bool pNJInventoryIsOpen = false;
        public void PNJInventory()
        {
            if (pNJInventoryIsOpen == false)
            {

                pNJInventoryPanel.SetActive(true);
                pNJInventoryIsOpen = true;
            }
            else
            {
                if (pNJInventoryIsOpen == true)
                {
                    pNJInventoryPanel.SetActive(false);
                    pNJInventoryIsOpen = false;
                }
            }
        }


        [SerializeField]
        public GameObject pNJIconInInventoryInstance;
        [SerializeField]
        public Transform layoutTransformParent;*/

        public bool HasEnoughResources(IInventoryItem item, int quantity)
        {
            Debug.Log("HasEnougResources ??");
            ///if (!items.TryGetValue(item, out int qtt))
            ///return false;

            if (3 >= quantity)
            {
                Debug.Log($"quantity is {items[item]}");
                return true;
            }

            else
            {
                Debug.Log($"you don't have enough ressources.");
                return false;
            }



        }

    }
}

