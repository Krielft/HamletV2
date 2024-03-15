using System.Collections;
using System.Collections.Generic;
using Hamlet.Game.Runtime.Player;
using Hamlet.Game.Runtime.PNJs;
using UnityEngine;

namespace Hamlet.Game.Runtime.Expeditions.UI
{
    /// <summary>
    /// Fenetre de creation dexpedition.
    /// Sur un objet dans la scene, sur une fenetre.
    /// </summary>
    public class ExpeditionCreationUI : MonoBehaviour
    {
        [SerializeField]
        private GuildeBuilding guildeBuilding;

        [SerializeField]
        private Transform root;
        [SerializeField]
        private ExpeditionPnjUI pnjUIPrefab;

        /// <summary>
        /// toggle créés
        /// </summary>
        private List<ExpeditionPnjUI> toggles;


        /// <summary>
        /// PNJs actuellement choisis
        /// </summary>
        public List<PNJ> expeditionPnjs;

        private void Awake()
        {
            expeditionPnjs = new();
            toggles = new();
        }


        public void Open()
        {
            expeditionPnjs.Clear();

            var pnjs = Inventory.Instance.Pnjs;
            foreach (PNJ pnj in pnjs)
            {
                ExpeditionPnjUI ui = Instantiate(pnjUIPrefab, root);
                ui.Bind(pnj, this);
                toggles.Add(ui);
            }
        }

        public void Close()
        {
            foreach(ExpeditionPnjUI ui in toggles)
            {
                ui.Unbind();
                Destroy(ui.gameObject);
            }
        }

        public void Validate()
        {
            guildeBuilding.StartExpedition(expeditionPnjs.ToArray());
            Close();
        }
    }
}
