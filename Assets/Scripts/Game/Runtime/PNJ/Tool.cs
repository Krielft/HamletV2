using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hamlet.Game.Runtime.Buildings;
using Hamlet.Game.Runtime.Player;

namespace Hamlet.Game.Runtime
{
    [System.Serializable]
    public class Tool 
    {
        public float Multiplier;
        public string nameTool;
        public int ID;
        public int battlePower;
        public int sellPrice;

        public Tool(string nameTool, float multiplier, int sellPrice, int ID, int battlePower)
        {
            this.nameTool = nameTool;
            this.Multiplier = multiplier;
            this.sellPrice = sellPrice;
            this.ID = ID;
            this.battlePower = battlePower;
        }
    }
}
