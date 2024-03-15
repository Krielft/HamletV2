using System.Collections;
using System.Collections.Generic;
using Hamlet.Game.Runtime.Player;
using UnityEngine;

namespace Hamlet.Game.Runtime.Expeditions
{
    [CreateAssetMenu(menuName = "Hamlet/ExpeditionData")]
    public class ExpeditionData : ScriptableObject
    { 
        public ResourceData[] rewards;
        public float expeditionTime = 1f;

        [NaughtyAttributes.ShowNativeProperty]
        public int RequiredPower
        {
            get
            {
                int power = 0;
                for (int i = 0; i < rewards.Length; i++)
                {
                    ResourceData r = rewards[i];
                    if (rewards == null)
                        continue;

                    power += r.expeditionPower;
                    
                }
                return power;
            }
        } 


    }
}
