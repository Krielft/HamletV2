using Hamlet.Game.Runtime.Player;
using Hamlet.Game.Runtime.PNJs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hamlet.Game.Runtime.Buildings.UI
{
    public class PNJInventorySlot : MonoBehaviour
    {
        [SerializeField]
        public PNJ pnj;
        public TextMeshProUGUI idText;
        [SerializeField]
        public Button button;
        [SerializeField]
        public Image image;
        public bool isSelected;

        private void Start()
        {
            idText.text = pnj.ID.ToString();
            button.onClick.AddListener(PNJToselection);
            image.color = Color.white;
        }
        public void Bind(PNJ pnj)
        {
            this.pnj = pnj;
        }
        public void Unbind()
        {
            pnj = null;
        }
        public void PNJToselection()
        {

            if (!isSelected)
            {
                //if (!Inventory.Instance.actualBuilding.GetComponent<Building>().pnjInSelection.Contains(pnj))
                //{
                if (Inventory.Instance.actualBuilding.GetComponent<Building>().pnjInSelection.Count < Inventory.Instance.actualBuilding.GetComponent<Building>().SlotsPNJsvalue)
                {
                    Inventory.Instance.actualBuilding.GetComponent<Building>().pnjInSelection.Add(pnj);
                    image.color = Color.red;
                    isSelected = true;
                }
                else
                {
                    Debug.Log("No Slots left");
                }
                //}
            }

            else
            {
                Inventory.Instance.actualBuilding.GetComponent<Building>().pnjInSelection.Remove(pnj);
                image.color = Color.white;
                isSelected = false;
            }





        }

    }
}
