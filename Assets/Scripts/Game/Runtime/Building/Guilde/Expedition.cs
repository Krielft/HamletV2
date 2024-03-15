using System.Collections;
using System.Collections.Generic;
using Hamlet.Game.Runtime.PNJs;
using UnityEngine;

namespace Hamlet.Game.Runtime.Expeditions
{
    public class Expedition
    {
        public PNJ[] PNJs;
        public ExpeditionData expeditionData;

        public Expedition(PNJ[] PNJs, ExpeditionData expeditionData)
        {
            this.PNJs = PNJs;
            this.expeditionData = expeditionData;
        }

        public float SuccessRate
        {
            get
            {
                float power = 0;
                for (int i = 0; i < PNJs.Length; i++)
                {
                    power += PNJs[i].BattlePower;
                }
                return power / expeditionData.RequiredPower;
            }
        }
    }
}
