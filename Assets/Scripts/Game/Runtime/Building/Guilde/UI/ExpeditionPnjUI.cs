using System.Collections;
using System.Collections.Generic;
using Hamlet.Game.Runtime.PNJs;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Hamlet.Game.Runtime.Expeditions.UI
{

    /// <summary>
    /// Sur un prefab de toggle
    /// </summary>
    public class ExpeditionPnjUI : MonoBehaviour
    {
        [SerializeField] Image icon;
        [SerializeField] TextMeshProUGUI power;

        public PNJ PNJ;
        private ExpeditionCreationUI creationUI;

        public void Bind(PNJ pNJ, ExpeditionCreationUI creationUI)
        {
            this.creationUI = creationUI;
            PNJ = pNJ;

            icon.sprite = pNJ.Data.sprite;
            power.text = pNJ.BattlePower.ToString();
        }

        public void Unbind()
        {

        }

        public void OnToggleChanges(bool isOn)
        {
            if (isOn)
                creationUI.expeditionPnjs.Add(PNJ);
            else
                creationUI.expeditionPnjs.Remove(PNJ);
        }
    }
}
