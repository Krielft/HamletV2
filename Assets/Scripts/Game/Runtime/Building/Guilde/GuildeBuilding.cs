using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hamlet.Game.Runtime.Player;
using Hamlet.Game.Runtime.PNJs;
using Hamlet.Game.Runtime.Expeditions.UI;

namespace Hamlet.Game.Runtime.Expeditions
{
    public class GuildeBuilding : MonoBehaviour
    {
        [SerializeField]
        ExpeditionData[] expeditions;
        [SerializeField]
        ExpeditionCreationUI expeditionCreationUI;

        public bool HasExpedition => currentExpedition != null;
        public Expedition currentExpedition;

        public float power;
        public float currentExpeditionTime;
        public ExpeditionData availableExpedition;


        public void ExpeditionTest()
        {

        }

        public void StartExpedition(PNJ[] PNJs)
        {
            currentExpedition = new Expedition(PNJs, availableExpedition);
            currentExpeditionTime = 0;
        }


        private void QuandClick()
        {
            expeditionCreationUI.Open();
        }
        // Update is called once per frame
        void Update()
        {
            if (!HasExpedition)
            {
                return;
            }

            if (currentExpeditionTime < currentExpedition.expeditionData.expeditionTime)
            {
                currentExpeditionTime += Time.deltaTime;
                return;
            }

            float randomNumber = UnityEngine.Random.value;
            if (randomNumber <= currentExpedition.SuccessRate)
            {
                var rewards = currentExpedition.expeditionData.rewards;
                for (int i = 0; i < rewards.Length; i++)
                {
                    Inventory.Instance.AddItem(rewards[i], 5);
                }
            }

            else
            {
                Debug.Log("Expedition failed !");
            }

            currentExpedition = null;
        }
    }
}
